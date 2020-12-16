using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using Notepad.Models;

namespace SimpleNotepad.Models
{
    class npDBContext : DbContext
    {
        public DbSet<Status> Statuses { get; set; }
    }
}
