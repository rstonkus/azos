/*<FILE_LICENSE>
 * Azos (A to Z Application Operating System) Framework
 * The A to Z Foundation (a.k.a. Azist) licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
</FILE_LICENSE>*/

using System.Threading.Tasks;

using Azos.Apps;
using Azos.Log;

namespace Azos.Security
{
  /// <summary>
  /// Provides security manager implementation that does nothing and always returns fake user instance
  /// </summary>
  public sealed class NOPSecurityManager : ApplicationComponent, ISecurityManagerImplementation
  {
    public NOPSecurityManager(IApplication app) : base(app)
    {
      m_PasswordManager = new DefaultPasswordManager(this);
      m_PasswordManager.Start();
      m_Cryptography = new DefaultCryptoManager(this);
      m_Cryptography.Start();
    }

    protected override void Destructor()
    {
      m_Cryptography.Dispose();
      m_PasswordManager.Dispose();
      base.Destructor();
    }

    private IPasswordManagerImplementation m_PasswordManager;
    private ICryptoManagerImplementation m_Cryptography;

    public override string ComponentLogTopic => CoreConsts.SECURITY_TOPIC;

    public bool SupportsTrueAsynchrony => false;

    public IPasswordManager PasswordManager  => m_PasswordManager;
    public ICryptoManager Cryptography => m_Cryptography;

    public User Authenticate(Credentials credentials) => User.Fake;
    public Task<User> AuthenticateAsync(Credentials credentials) => Task.FromResult(User.Fake);

    public void Configure(Conf.IConfigSectionNode node) {}

    public User Authenticate(SysAuthToken token) => User.Fake;
    public Task<User> AuthenticateAsync(SysAuthToken token) => Task.FromResult(User.Fake);

    public void Authenticate(User user) {}
    public Task AuthenticateAsync(User user) => Task.CompletedTask;

    public AccessLevel Authorize(User user, Permission permission) => AccessLevel.DeniedFor(user, permission);
    public Task<AccessLevel> AuthorizeAsync(User user, Permission permission) => Task.FromResult(AccessLevel.DeniedFor(user, permission));

    public Task<IEntityInfo> LookupEntityAsync(string uri) => null;

    public SecurityLogMask SecurityLogMask{ get; set;}
    public MessageType SecurityLogLevel { get; set; }

    public Conf.IConfigSectionNode GetUserLogArchiveDimensions(IIdentityDescriptor identity)
    {
      return null;
    }

    public void LogSecurityMessage(SecurityLogAction action, Log.Message msg, IIdentityDescriptor identity = null)
    {
    }
  }
}
