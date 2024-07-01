using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesBase.models
{
    public class Usuario
    {
        private string user;
        private string contra;

        public Usuario(){}
        public Usuario(string user, string contra)
        {
            this.user = user;
            this.contra = contra;
        }      

        public String User
        {
            get { return user; }
            set { user = value; }
        }

        public String Contra
        {
            get { return contra; }
            set { contra = value; }
        }
    }
}
