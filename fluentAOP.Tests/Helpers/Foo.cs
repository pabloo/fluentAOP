/* 風覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧藍
   | Copyright ｩ Pablo Orozco (pablo@orozco.me).                              |
   | All rights reserved.                                                     |
   |                                                                          |
   | Licensed under the Apache License, Version 2.0 (the "License");          |
   | you may not use this file except in compliance with the License.         |
   | You may obtain a copy of the License at                                  |
   |                                                                          |
   | http://www.apache.org/licenses/LICENSE-2.0                               |
   |                                                                          |
   | Unless required by applicable law or agreed to in writing, software      |
   | distributed under the License is distributed on an "AS IS" BASIS,        |
   | WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. |
   | See the License for the specific language governing permissions and      |
   | limitations under the License.                                           |
   風覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧覧藍 */

using System;
using System.Linq;
using Xunit;

namespace FluentAop.Tests
{

    public interface IFoo
    {
        string Name { get; set; }
        string Description { get; set; }
        //bool WasExecuted { get; set; }

        void Go();
        void OverloadedGo(string a);
        void OverloadedGo(int a);
        void Fail();
        int Return();

        T GenericGo<T>(T t);
        //void GoWithAnOutParam(out int a);
        //void GoWithARefParam(ref int a);

    }

	public class Foo : IFoo
    {
        public Foo()
        {
            name = "foo";
        }

        public bool WasExecuted {get; set; }

		private string name;
		public virtual string Name
		{
			get
			{
                WasExecuted = true;
				return name;
			}

			set
			{
				name = value;
                WasExecuted = true;
			}
		}

		public string Description { get; set; }

		public virtual void Go()
		{
            WasExecuted = true;
		}

		public void OverloadedGo(string a)
		{
            WasExecuted = true;
		}

		public void OverloadedGo(int a)
		{
            WasExecuted = true;
		}

		public void Fail()
		{
            WasExecuted = true;
			throw new InvalidOperationException();
		}

		public int Return()
		{
            WasExecuted = true;
			return 1;
		}

		public T GenericGo<T>(T t)
		{
            WasExecuted = true;
            return t; //default(T);
		}

		//public void GoWithAnOutParam(out int a)
		//{
		//	WasExecuted = true;
		//	a = -1;
		//}

		//public void GoWithARefParam(ref int a)
		//{
		//	WasExecuted = true;
		//	a = -1;
		//}

	}
}
