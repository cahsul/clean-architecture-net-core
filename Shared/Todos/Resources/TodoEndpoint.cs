using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Todos.Resources
{
    public static class TodoEndpoint
    {
        public static class V1
        {
            public const string Path = nameof(V1);

            public static class Todo
            {
                public static readonly string Path = $"{V1.Path}/{nameof(Todo)}";
                public const string EndPoint = "";

                public static class Create
                {
                    public static readonly string Path = $"{Todo.Path}/{nameof(Create)}";
                    public const string EndPoint = nameof(Create);
                }

                public static class Update
                {
                    public static readonly string Path = $"{Todo.Path}/{nameof(Update)}";
                    public const string EndPoint = nameof(Update) + "/{Id:guid}";
                }

                public static class Delete
                {
                    public static readonly string Path = $"{Todo.Path}/{nameof(Delete)}";
                    public const string EndPoint = nameof(Delete) + "/{Id:guid}";
                }

                //public static class List
                //{
                //    public static readonly string Path = $"{Apps.Path}/{nameof(List)}";
                //    public const string EndPoint = nameof(List);
                //}
            }
        }
    }
}
