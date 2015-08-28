
namespace Playground.CQRS.Web.Models
{
    public class AppSettingModel
    {
        public string FirstVariable { get; private set; }

        public AppSettingModel(string firstVariable)
        {
            this.FirstVariable = firstVariable;
        }
    }
}