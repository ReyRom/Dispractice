using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Data;
using Avalonia.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dispractice.Extensions
{
    public class TreeItemsTemplateSelector : ITreeDataTemplate
    {

        [Content]
        public Dictionary<Type, ITreeDataTemplate> Templates { get; } = new Dictionary<Type, ITreeDataTemplate>();


        public Control? Build(object? param)
        {
            var type = param.GetType();
            var template = this.Templates[type];
            var control = template.Build(param);

            return control;
        }

        public InstancedBinding? ItemsSelector(object item)
        {
            var type = item.GetType();
            var template = this.Templates[type];
            var control = template.ItemsSelector(item);

            return control;
        }

        public bool Match(object? data)
        {
            return Templates.Any(t=>t.Value.Match(data));
        }
    }
}
