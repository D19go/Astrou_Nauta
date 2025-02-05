using UnityEngine;

public class spanw : MonoBehaviour
{
    [SerializeField] private GameObject inimigo;
    [SerializeField] private GameObject inimigo2;
    [SerializeField] private GameObject inimigo3;

    [SerializeField] GameObject gm;

    [SerializeField] private GameObject inimigoV2;
    [SerializeField] private GameObject inimigo2V2;
    [SerializeField] private GameObject inimigo3V2;

    [SerializeField] private GameObject Boss1;
    [SerializeField] private GameObject Boss2;
    [SerializeField] private GameObject Boss3;
    [SerializeField] private GameObject canvas;

    [SerializeField] private bool PodeWave = false;
    [SerializeField] private int Wave = 0;
    [SerializeField] private int total = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!PodeWave)
        {
            return;
        
        }
        if (total >= 9)  // Alterado para gerar 9 inimigos no total
        {
            
            // timeSpanw();
            for (int i = 0; i < 1; i++)
            {
                SpawnEnemy(inimigo, i);
                SpawnEnemy(inimigo2, i);
                SpawnEnemy(inimigo3, i);
                SpawnEnemy(inimigo3, i);
            }
           
            for(int i = 0; i < 1; i++){
                SpawnEnemy(inimigoV2, i);
                SpawnEnemy(inimigoV2, i);
                SpawnEnemy(inimigo2V2, i);
                SpawnEnemy(inimigo3V2, i);
                SpawnEnemy(inimigo3V2, i);
            }
                
            Wave += 1;
            total = 0;
            gm.GetComponent<MissoesP1>().Wave();
        }
        if(total >= 9 && Wave>= 3){

            for(int i = 0; i < 3; i++){
                SpawnEnemy(inimigoV2, i);
                SpawnEnemy(inimigo2V2, i);
                SpawnEnemy(inimigo3V2, i);
            }
            total = 0;
        }
        
        
        
        /*if(Wave == 5){
            CriarBoss();
        }
        if(Wave == 6){
            CriarBoss();
        }*/
        
    }
    void SpawnEnemy(GameObject enemyPrefab, int positionIndex)
    {
        if(total >= 9){

            // Instancie o inimigo
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            newEnemy.transform.position = new Vector3(transform.position.x, 11, transform.position.z);

            // Adicione a força
            newEnemy.GetComponent<Rigidbody>().AddForce(Vector3.up * 2000);
        }

        
    }
  

    void CriarBoss()
    {   
        Debug.Log("n");
        if(Wave == 3){
            Boss1.SetActive(true);

        }
        if(Wave == 5){
            Boss2.SetActive(true);

        }
        if(Wave == 6){
            Boss3.SetActive(true);

        }

    }

    public void Comeca(bool missaoDarPulos)
    {
        PodeWave = missaoDarPulos;
    }

    public void Quantos(int menos1)
    {
        total += menos1;
        if( total >= 9)
        {
            MissoesGeral.instance.arvoreCompleta = true;
            MissoesGeral.instance.AlternarMissoes(MissoesGeral.instance.missaoArvore, MissoesGeral.instance.missaoSobreviver);
        }
    }

}
