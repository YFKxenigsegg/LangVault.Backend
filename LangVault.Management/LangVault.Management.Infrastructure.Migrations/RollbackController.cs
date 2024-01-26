namespace LangVault.Management.Infrastructure.Migrations;
[ApiController]
[Route("api/[controller]/[action]")]
public class RollbackController(IMigrationRunner migrationRunner)
    : ControllerBase
{
    private readonly IMigrationRunner _migrationRunner = migrationRunner;

    [HttpGet]
    public ActionResult Rollback()
    {
        _migrationRunner.Rollback(1);
        return Ok();
    }
}
