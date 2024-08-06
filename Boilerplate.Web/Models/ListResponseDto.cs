using Boilerplate.Infrastructure.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace Boilerplate.Web.Models
{
    public class ListResponseDto<T>
    {
        private List<T> Data { get; set; }

        public ListResponseDto(List<T> _data, List<string> _actions=null)
        {
            Data = _data;
            Actions = _actions;
        }

        public Dictionary<string, string> Columns
        {
            get
            {
                return Shared.GetDisplayNameFields<T>(Actions != null && Actions.Any());
            }
        }

        public List<Dictionary<string, dynamic>> Rows
        {
            get
            {

                var rows = new List<Dictionary<string, dynamic>>();

                foreach (var row in Data)
                {
                    var dict = new Dictionary<string, dynamic>();
                    var totalProperties = row.GetType().GetProperties();

                    if (Actions != null && Actions.Any())
                    {
                        var keyField = Shared.GetKeyNameField<T>();

                        var actions = string.Empty;
                        foreach (var action in Actions)
                        {
                            actions += string.Format(action,keyField.GetValue(row));
                        }

                        dict.Add("Action", actions);
                    }

                   
                    foreach (var column in Columns)
                    {
                        var property = totalProperties.FirstOrDefault(w => w.Name == column.Key);
                        if (property != null)
                        {
                            var val = property.GetValue(row);
                            dict.Add(column.Key, val);
                        }
                    }

                    rows.Add(dict);
                }

                return rows;
            }
        }

        private List<string> Actions { get; set; }
        public bool HasActionColumn { get { return Actions != null && Actions.Any(); } }


    }
}
