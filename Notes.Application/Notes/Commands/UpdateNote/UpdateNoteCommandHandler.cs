using MediatR;
using Notes.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;
using Notes.Application.Common.Exeption;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, Unit>
    {
        private readonly INotesDbContext _context;
        public UpdateNoteCommandHandler(INotesDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Notes.FirstOrDefaultAsync(_ => _.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId !=request.UserId)
            {
                throw new NotFoundExeption(nameof(Note), request.Id);
            }
            entity.Detail = request.Details;
            entity.Title = request.Title;
            entity.UpdateDate= DateTime.Now;
            await _context.SaveChangesAsync(cancellationToken);

            return   Unit.Value;
        }               
    }
}
