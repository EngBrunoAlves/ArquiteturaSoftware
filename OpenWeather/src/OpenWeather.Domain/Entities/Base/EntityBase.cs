namespace OpenWeather.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;
    using System.Text;

    public class EntityBase
    {
        [Key]
        public long Id { get; set; }

        private PropertyInfo[] propertyInfos;

        public override string ToString()
        {
            if (propertyInfos == null)
                propertyInfos = GetType().GetProperties();

            var sb = new StringBuilder();

            foreach (var info in propertyInfos)
            {
                var value = info.GetValue(this, null) ?? "(null)";
                sb.AppendLine(info.Name + ": " + value);
            }

            return sb.ToString();
        }
    }
}