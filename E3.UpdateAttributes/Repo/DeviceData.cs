using System.Collections.Generic;
using System.Xml.Linq;

namespace E3.UpdateAttributes.Repository
{
    public class DeviceData
    {
        public string ArticleNumber { get; set; }
        public List<string> AttributesToUpdate { get; set; } = new List<string>();
        private Dictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();
        public void SetValue(string Name, string Value)
        {
      
                    if (Attributes.ContainsKey(Name))
                    {
                        Attributes[Name] = Value;
                    }
                    else
                    {
                        Attributes.Add(Name, Value);
                    }  
        }

        public string GetValue(string Name)
        {

                    if (Attributes.ContainsKey(Name))
                    {
                        return Attributes[Name];
                    }
                    else
                    {
                        return "";
                    }
        }
        public bool HasValue(string Name)
        {
           
                    if (Attributes.ContainsKey(Name))
                    {
                        return string.IsNullOrWhiteSpace(Attributes[Name]);
                    }
                    else
                    {
                        return false;
                    }
            
        }
    }
}