
namespace Playground.CQRS.Web.Models
{
    public class SessionTestModel
    {
        public int Number { get; set; }

        public SessionTestModel(int number = 0)
        {
            this.Number = number;
        }
    }
}