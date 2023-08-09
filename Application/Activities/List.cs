using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> 
        {
            
        }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            private readonly ILogger<List> _logger;
            public Handler(DataContext context, ILogger<List> logger)
            {
                _logger = logger;
                _context = context;                
            }
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    for(var i=0; i<3; i++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        await Task.Delay(1000, cancellationToken);
                        _logger.LogInformation($"Task {i} has completed");
                    }
                }
                catch (System.Exception)
                {
                    _logger.LogInformation("Task was cancelled");
                }

                return await _context.Activities.ToListAsync();
            }
        }
    }
}


// MediatR, C#/.NET platformunda kullanılan bir kütüphanedir ve Mediator pattern'ı uygulamak için tasarlanmıştır. Bu kütüphane, .NET uygulamalarında CQRS (Command Query Responsibility Segregation) tasarım desenini uygulamak için yardımcı olur.

// CQRS, uygulamanın veri okuma (query) ve veri yazma (command) işlemlerini ayrı ayrı ele alarak, veri değişiklikleri ve veri sorgulamalarının farklı yollarla yapılmasını sağlayan bir tasarım desenidir. Bu desen, yazma işlemlerinin okuma işlemlerinden farklı gereksinimleri olduğu durumlarda tercih edilir ve uygulamanın ölçeklenebilirliğini artırır.

// MediatR, bu CQRS desenini uygulamak için mediator pattern'ını kullanır. Uygulama içindeki komutları (commands) ve sorguları (queries) bir aracı nesne olan mediator üzerinden yönlendirir. Bu sayede, komutlar ve sorgular arasındaki bağımlılıkları azaltır ve kodun daha esnek ve bakımı kolay hale gelmesini sağlar.

// MediatR kütüphanesi, .NET uygulamalarında iş katmanında kullanılan komutları ve sorguları kolayca yönetmek için kullanılabilir. Bu kütüphane, CQRS desenini uygulamak isteyen geliştiricilere nesneler arasındaki iletişimi düzenlemek için güçlü bir araç sağlar ve kodun daha modüler ve anlaşılır olmasına yardımcı olur.