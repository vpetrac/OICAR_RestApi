using System;
namespace OicarWebApi.Repository
{
	public interface IUserRepository
	{
        public Task<int> CreateUser(
            string firstName,
            string lastName,
            string email,
            byte passwordHash);

        public Task<int> GetUser(int id);

        public Task<int> UpdateUser(
            string firstName,
            string lastName,
            string email,
            byte passwordHash);

        public Task<int> DeleteUser(int id);
    }


}

