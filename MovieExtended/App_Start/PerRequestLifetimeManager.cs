using System.Web;
using Microsoft.Practices.Unity;

namespace MovieExtended
{
    public class PerRequestLifetimeManager : LifetimeManager
    {
        public const string Key = "SingletonPerRequest";
        public override object GetValue()
        {
            return HttpContext.Current.Items[Key];
        }

        public override void SetValue(object newValue)
        {
            HttpContext.Current.Items[Key] = newValue;
        }

        public override void RemoveValue()
        {
            throw new System.NotImplementedException();
        }
    }
}