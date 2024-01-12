using MediatR;
using Notes.Application.Interfaces;
using Notes.Application.Common.Exeption;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler: IRequestHandler<DeleteNoteCommand, Unit>
    {
        private  readonly INotesDbContext _context;
        public DeleteNoteCommandHandler(INotesDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Notes.FindAsync(new object[] {request.Id}, cancellationToken);

            if(entity is null || entity.UserId!=request.UserId)
            {
                throw new NotFoundExeption(nameof(Note), request.Id);
            }
             _context.Notes.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
