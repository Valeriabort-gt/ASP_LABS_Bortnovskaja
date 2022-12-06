﻿using MediatR;
using Domain;

namespace Application.Invoices.Commands.CreateInvoice
{
    public class CreateInvoiceCommand : IRequest<Invoice>
    {
        public DateTime createDate { get; set; }
        public string number { get; set; }
        //public int organizationID { get; set; }
        public Organization organization { get; set; }
        //public int roomID { get; set; }
        public Room room { get; set; }
        public decimal puySum { get; set; }
        public DateTime payDate { get; set; }
        //public int employeeID { get; set; }
        public Employee employee { get; set; }  
    }
}
