using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PartnerFeatures.Commands
{
    public class CreatePartnerCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int INN { get; set; }
        public int OGRN { get; set; }
        public int OKPO { get; set; }
        public int KPP { get; set; }
        public string LegalAddress { get; set; }
        public string ActuallAddress { get; set; }
        public string PostallAddress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public class CreatePartnerCommandHandler : IRequestHandler<CreatePartnerCommand, int>
        {
            private readonly IPartnerDbContext _context;
            public CreatePartnerCommandHandler(IPartnerDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreatePartnerCommand command, CancellationToken cancellationToken)
            {
                var Partner = new Partners();
                Partner.Name = command.Name;
                Partner.INN = command.INN;
                Partner.OGRN = command.OGRN;
                Partner.OKPO = command.OKPO;
                Partner.KPP = command.KPP;
                Partner.LegalAddress = command.LegalAddress;
                Partner.ActuallAddress = command.ActuallAddress;
                Partner.PostallAddress = command.PostallAddress;
                Partner.Phone = command.Phone;
                Partner.Email = command.Email;
                _context.Partners.Add(Partner);
                await _context.SaveChangesAsync();
                return Partner.Id;
            }
        }
    }
}
