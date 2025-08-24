using System;
using System.Data;
using DVLD.DataAccess;
using DVLD.Entities;
using DVLD.WinForms.Utils;

namespace DVLD.BusinessLogic
{
    public class clsUser
    {
        public int UserID { get; private set; }
        public clsPerson PersonInfo { get; }
        public string Username { get; set; }
        public string HashedPassword { get; private set; }
        public bool IsActive { get; set; }
        private enMode Mode { get; set; }

        public clsUser(clsPerson person, string username, string password, bool isActive)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person), "Person cannot be null.");
            }

            UserID = -1;
            PersonInfo = person;
            Username = username;
            HashedPassword = clsPasswordHelper.CreateHashPasswordWithSalt(password);
            IsActive = isActive;
            Mode = enMode.AddNew;
        }

        private clsUser(clsUserEntity UserEntity)
        {
            UserID = UserEntity.UserID;
            PersonInfo = clsPerson.Find(UserEntity.PersonID);
            Username = UserEntity.Username;
            HashedPassword = UserEntity.HashedPassword;
            IsActive = UserEntity.IsActive;
            Mode = enMode.Update;
        }

        public static bool IsPersonHasUser(int PersonID)
        {
            return clsUserData.IsPersonHasUser(PersonID);
        }

        public static bool IsUserExist(int UserID)
        {
            return clsUserData.IsUserExist(UserID);
        }

        public static bool IsUserExist(string Username)
        {
            return clsUserData.IsUserExist(Username);
        }

        public static clsUser Find(int UserID)
        {
            clsUserEntity UserEntity = clsUserData.FindUserByID(UserID);
            return UserEntity != null ? new clsUser(UserEntity) : null;
        }

        public static clsUser Find(string Username)
        {
            clsUserEntity UserEntity = clsUserData.FindUserByUsername(Username);
            return UserEntity != null ? new clsUser(UserEntity) : null;
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static bool Delete(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
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
            userEntity.HashedPassword = User.HashedPassword;
            userEntity.IsActive = User.IsActive;

            return userEntity;
        }

        public void SetPassword(string password)
        {
            this.HashedPassword = clsPasswordHelper.CreateHashPasswordWithSalt(password);
        }

        public bool ChangePassword(string newPassword)
        {
            this.HashedPassword = clsPasswordHelper.CreateHashPasswordWithSalt(newPassword);
            return this.Save();
        }

        public bool VerifyPassword(string enteredPassword)
        {
            return clsPasswordHelper.VerifyPassword(enteredPassword, this.HashedPassword);
        }

    }
}