//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kingsman.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Staff
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public int PositionID { get; set; }
        public string GenderCode { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    
        public virtual Gender Gender { get; set; }
        public virtual Position Position { get; set; }
    }
}
