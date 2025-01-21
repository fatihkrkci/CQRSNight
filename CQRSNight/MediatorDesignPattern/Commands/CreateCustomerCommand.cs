﻿using MediatR;

namespace CQRSNight.MediatorDesignPattern.Commands
{
    public class CreateCustomerCommand : IRequest
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
    }
}
