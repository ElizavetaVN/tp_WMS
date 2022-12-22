using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.RegistrationWriteFeatures.Commands
{
    public class DeleteRegistrationWriteByIdCommand : IRequest<RegistrationWrite>
    {
        public int Id { get; set; }
        public class DeleteRegistrationWriteByIdCommandHandler : IRequestHandler<DeleteRegistrationWriteByIdCommand, RegistrationWrite>
        {
            private readonly IRegistrationWriteDbContext _context;
            public DeleteRegistrationWriteByIdCommandHandler(IRegistrationWriteDbContext context)
            {
                _context = context;
            }
            public async Task<RegistrationWrite> Handle(DeleteRegistrationWriteByIdCommand command, CancellationToken cancellationToken)
            {
                var RegistrationWrite = await _context.RegistrationWrite.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (RegistrationWrite == null) return default;
                _context.RegistrationWrite.Remove(RegistrationWrite);
                await _context.SaveChangesAsync();
                return RegistrationWrite;
            }
        }
    }
}
