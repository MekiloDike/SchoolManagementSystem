using SchoolManagementUI.ViewModel;

namespace SchoolManagementUI.Service
{
    public interface IUser
    {
        public  Task Signin(LoginVM detail);
        public Task Register(RegisterVM registerVM);
    }
}
