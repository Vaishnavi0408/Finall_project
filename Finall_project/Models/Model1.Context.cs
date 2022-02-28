﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Finall_project.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    using System.Collections.Generic;

    public partial class LIBRARYDBEntities1 : DbContext
    {
        internal IEnumerable<object> users;
        private decimal id;
        internal object BOOK_ID;
        internal object user;

        public LIBRARYDBEntities1()
            : base("name=LIBRARYDBEntities1")
        {
        }

        public LIBRARYDBEntities1(decimal id)
        {
            this.id = id;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<MEMBERINFO> MEMBERINFOes { get; set; }
        public virtual DbSet<LibraryData> LibraryDatas { get; set; }
        public virtual DbSet<LibraryHistory> LibraryHistories { get; set; }
        public virtual DbSet<LoginTab> LoginTab { get; set; }
        public object LoginTab { get; internal set; }

        public virtual ObjectResult<GetBooksDetails_Result> GetBooksDetails()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetBooksDetails_Result>("GetBooksDetails");
        }
    
        public virtual ObjectResult<string> LoginProc(string p_uname, string p_pass)
        {
            var p_unameParameter = p_uname != null ?
                new ObjectParameter("p_uname", p_uname) :
                new ObjectParameter("p_uname", typeof(string));
    
            var p_passParameter = p_pass != null ?
                new ObjectParameter("p_pass", p_pass) :
                new ObjectParameter("p_pass", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("LoginProc", p_unameParameter, p_passParameter);
        }
    }
}
