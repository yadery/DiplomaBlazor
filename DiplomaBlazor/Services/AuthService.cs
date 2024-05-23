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
        public AuthService() 
        {
            _preferences = Preferences.Default;
        }
        public bool IsAuthenticated => _preferences.ContainsKey(LogInKey);

        public void SignIn()
        {
            //проверка юзера
            _preferences.Set(LogInKey, true);
        }

        public void SignOut() 
        {
            _preferences.Remove(LogInKey);
        }
    }
}
