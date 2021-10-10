using System.Collections.Generic;
using UnityEngine;


public class StateMachine<T> 
{
    public State<T> currentState { get; private set; }
    public State<T> previousState { get; private set; }

    /// <summary>
    /// The owner of the script. Used to by the states to access the owner's components.
    /// </summary>
    public T owner;

    /// <param name="owner">The owner of the script. Used to by the states to access the owner's components.</param>
    public StateMachine(T owner) {
        this.owner = owner;
        currentState = null;
    }

    /// <summary>
    /// Change from one state to another
    /// </summary>
    /// <param name="state">State to change to</param>
    public void ChangeState(State<T> state) {
        RemoveState();
        AddState(state);
    }

    /// <summary>
    /// Removes the current state
    /// </summary>
    private void RemoveState() {
        if (currentState != null) {
            currentState.ExitState(owner);
            previousState = currentState;
            currentState = null;
        }
    }

    /// <summary>
    /// Adds a new state
    /// </summary>
    /// <param name="newState">State to add</param>
    private void AddState(State<T> newState) {
        if (currentState == null) {
            currentState = newState;
            currentState.EnterState(owner);
        }
    }

    /// <summary>
    /// Updates the current state
    /// </summary>
    public void Update() {
        if (currentState != null)
            currentState.UpdateState(owner);
    }
    /// <summary>
    /// Updates the current state when useing FixedUppdate
    /// </summary>
    public void FixedUpdate() {
        if (currentState != null)
            currentState.FixedUpdateState(owner);
    }
}