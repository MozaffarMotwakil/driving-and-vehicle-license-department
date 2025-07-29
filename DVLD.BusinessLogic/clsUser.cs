using System;
using System.Data;
using DVLD.DataAccess;
using DVLD.Entities;

namespace DVLD.BusinessLogic
{
    public class clsUser
    {
        public int UserID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public enMode Mode { get; set; }

        public clsUser()
        {
            UserID = -1;
            PersonInfo = null;
            Username = Password = string.Empty;
            IsActive = false;
            Mode = enMode.AddNew;
        }

        private clsUser(clsUserEntity UserEntity)
        {
            UserID = UserEntity.UserID;
            PersonInfo = clsPerson.Find(UserEntity.PersonID);
            Username = UserEntity.Username;
            Password = UserEntity.Password;
            IsActive = UserEntity.IsActive;
            Mode = enMode.Update;
        }

        public static bool IsUserExist(int UserID)
        {
            return DataAccess.clsUserData.IsUserExist(UserID);
        }

        public static bool IsUserExist(string Username)
        {
            return DataAccess.clsUserData.IsUserExist(Username);
        }

        public static clsUser Find(int UserID)
        {
            clsUserEntity UserEntity = DataAccess.clsUserData.FindUserByID(UserID);
            return UserEntity != null ? new clsUser(UserEntity) : null;
        }

        public static clsUser Find(string Username)
        {
            clsUserEntity UserEntity = DataAccess.clsUserData.FindUserByUsername(Username);
            return UserEntity != null ? new clsUser(UserEntity) : null;
        }

        public static DataTable GetAllUsers()
        {
            return DataAccess.clsUserData.GetAllUsers();
        }

        public static bool Delete(int UserID)
        {
            return DataAccess.clsUserData.DeleteUser(UserID);
        }

        public bool Save()
        {
            clsUserEntity userEntity = _MapUserObjectToUserEntity(this);

            switch (Mode)
            {
                case enMode.AddNew:
                    if (clsUserData.AddNewUser(userEntity))
                    {
                        this.UserID = userEntity.UserID;
                        this.Mode = enMode.Update;
                        return true;
                    }

                    return false;
                case enMode.Update:
                    return clsUserData.UpdateUser(userEntity);
                default:
                    return false;
            }
        }

        private static clsUserEntity _MapUserObjectToUserEntity(clsUser User)
        {
            clsUserEntity userEntity = new clsUserEntity();

            userEntity.UserID = User.UserID;
            userEntity.PersonID = User.PersonInfo.PersonID;
            userEntity.Username = User.Username;
            userEntity.Password = User.Password;
            userEntity.IsActive = User.IsActive;

            return userEntity;
        }
    }
}
