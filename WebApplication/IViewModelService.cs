using WebApplication.Models;

namespace WebApplication.Services
{
    public interface IViewModelService
    {
        DashboardViewModel GetDashboardViewModel();
    }
}