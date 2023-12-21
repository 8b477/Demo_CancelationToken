 [Route("api/[controller]")]
    [ApiController]
    public class Auth0Controller : ControllerBase
    {

        private readonly ILogger<Auth0Controller> _logger;

        public Auth0Controller(ILogger<Auth0Controller> logger) => (_logger) = (logger);


        /// <summary>
        /// Démo comment mettre en place la possibilité d'annulé une requête sur une méthode asynchrone
        /// </summary>
        /// <param name="cancel"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet(nameof(AnnulationDeRequeteSurUneMethodeAsynchrone))]
        public async Task<string> AnnulationDeRequeteSurUneMethodeAsynchrone(CancellationToken cancel)
        {

            _logger.LogWarning("Début de la demande !!!!!!!");

            await Task.Delay(3000,cancel);

            _logger.LogWarning("fin de l'attente");

            return "finito";
        }


        /// <summary>
        /// Démo comment mettre en place la possibilité d'annulé une requête sur une méthode synchrone
        /// </summary>
        /// <param name="cancel"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet(nameof(AnnulationDeRequeteSurUneMethodeSynchrone))]
        public async Task<string> AnnulationDeRequeteSurUneMethodeSynchrone(CancellationToken cancel)
        {

            _logger.LogWarning("Début de la demande !!!!!!!");

            for (int i = 0; i < 10; i++)
            {
                _logger.LogWarning("Dans la boucle i = " + i);
                cancel.ThrowIfCancellationRequested();
                Thread.Sleep(2000);
            }
            
            _logger.LogWarning("fin de l'attente");

            return "finito";
        }
    }