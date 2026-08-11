using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonSceneManager : MonoBehaviour
{
    public string nomeDaCena = "Gameplay";
    public float tempoDeEspera = 0.5f;

    // Este é o método que você vai chamar no OnClick() do botão
    public void IniciarJogo()
    {
        StartCoroutine(CarregarCenaComDelay());
    }

    private IEnumerator CarregarCenaComDelay()
    {

        yield return new WaitForSeconds(tempoDeEspera);

        SceneManager.LoadScene(nomeDaCena);
    }
}
