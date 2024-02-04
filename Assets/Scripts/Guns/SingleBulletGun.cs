namespace Guns
{
    public class SingleBulletGun : Gun
    {
        public override void Shoot()
        {
            GetBullet().AddForce(this.transform.up);
        }
 
    }
}