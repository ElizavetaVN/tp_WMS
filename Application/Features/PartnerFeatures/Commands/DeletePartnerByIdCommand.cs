using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PartnerFeatures.Commands
{
    public class DeletePartnerByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeletePartnerByIdCommandHandler : IRequestHandler<DeletePartnerByIdCommand, int>
        {
            private readonly IPartnerDbContext _context;
            public DeletePartnerByIdCommandHandler(IPartnerDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeletePartnerByIdCommand command, CancellationToken cancellationToken)
            {
                var Partner = await _context.Partners.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (Partner == null) return default;
                _context.Partners.Remove(Partner);
                await _context.SaveChangesAsync();
                return Partner.Id;
            }
        }
    }
}
