namespace Guns
{
    public class TripleBulletGun:Gun
    {
         
        public override void Shoot()
        {
            var up = transform.up;
            var right = transform.right;
            GetBullet().AddForce(up);
            GetBullet().AddForce((up + right).normalized);
            GetBullet().AddForce((up - right).normalized);
             
        }
    }
}