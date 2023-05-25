using Unity.Mathematics;
using UnityEngine;

namespace DefaultNamespace
{
    public class DrunkMovable : IMovable
    {
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
        private Transform _transform;

        public void Configure(Animator animator, SpriteRenderer spriteRenderer, Transform transform)
        {
            _animator = animator;
            _spriteRenderer = spriteRenderer;
            _transform = transform;
        }

        public void DoMove(float speed)
        {
            // Check input
            var horizontal = Input.GetAxis("Horizontal");
            _animator.SetFloat("Horizontal", math.abs(horizontal));
            _spriteRenderer.flipX = horizontal < 0;
            // Move according the input
            var x = horizontal * speed * Time.deltaTime;
            _transform.Translate(-x, 0.0f, 0.0f);
        }
    }
}