
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaBlazor.Services
{
    internal class AuthService
    {
        private const string LogInKey = "logged-in";
        private readonly IPreferences _preferences;
        private readonly DatabaseContext _context;

        public AuthService(DatabaseContext context) 
        {
            _preferences = Preferences.Default;
            _context = context;
        }
        public bool IsAuthenticated => _preferences.ContainsKey(LogInKey);

        public async Task<MethodResult> SignUpAsync(SignUpModel model)
        {
            var user = new User
            {
                Name = model.Name,
                UserName = model.Username,
                Password = model.Password,
            };

            if (await _context.AddItemAsync<User>(user))
            {
                SetUser(user);
                return MethodResult.Success();
            }
            return MethodResult.Fail(null);
        }
        public async Task<MethodResult> SignIn(SignInModel model)
        {
            var users = await _context.GetFileteredAsync<User>(
                u => u.UserName == model.Username && u.Password == model.Password);
            var user = users.FirstOrDefault();

            if (user != null) 
            {
                SetUser(user);
                return MethodResult.Success();
            }

            return MethodResult.Fail("Неверные данные");           
        }

        private void SetUser(User user)
        { 
            var loggedInUser = new LoggedInUser(user.Id, user.Name);
            _preferences.Set(LogInKey, loggedInUser.ToJson());
        }
        
        public void SignOut() 
        {
            _preferences.Remove(LogInKey);
        }
    }
}
