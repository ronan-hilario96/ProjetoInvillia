namespace CompartilharJogos.Domain.Users
{
    public class SaveUser
    {
        private readonly IUserRepository _repository;
        public SaveUser(IUserRepository repository)
        {
            _repository = repository;
        }
        public void Save(UserDto dto)
        {
            var user = new User(dto.Username, dto.Password, dto.Role);

            _repository.Save(user);
        }
    }
}
