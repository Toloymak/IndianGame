using UnityEngine;

namespace Extensions
{
    public static class GameObjectExtensions
    {
        public static bool IsClicked(this GameObject gameObject, int mouseButton)
        {
                if (!Input.GetMouseButton(mouseButton))
                    return false;

                var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var mousePos2D = new Vector2(mousePosition.x, mousePosition.y);
            
                var hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                
                if (hit.collider != null &&  hit.collider.gameObject == gameObject)
                {
                    return true;
                }

                return false;
        }
    }
}