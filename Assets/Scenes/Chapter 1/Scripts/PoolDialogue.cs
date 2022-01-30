public class PoolDialogue : Interactable {
    public Dialogue[] Interactions;

    void Update() {
        if (PlayerNearby && Lunaria.IsInteracting()) {
            Lunaria.Player.Animator.enabled = false;
            Lunaria.StopMovement = Lunaria.StopInteraction = true;

            Lunaria.ShowDialogues(Interactions, 0, () => {
                Lunaria.Player.Animator.enabled = true;
                Lunaria.StopMovement = Lunaria.StopInteraction = false;
            });
        }
    }
}
