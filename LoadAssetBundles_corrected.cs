using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System;
/*NO PONGO MI NOMBRE porque el codigo no es originalmente mio. son dos codigos que combine que 
por alguna razon A MI no me funcionaban por separado
una buena parte la agarre de aqui:
https://docs.unity3d.com/Manual/UnityWebRequest-CreatingDownloadHandlers.html
la de online
la local creo que me base de aqui:
https://www.youtube.com/watch?v=Vgvka2_jBJw
*/
public class LoadAssetBundles_corrected : MonoBehaviour {

	


	AssetBundle myLoaderAssetbundle;
	 public string path_folder_de_donde_sale_el_assetbundle;
	public string nombre_del_prefab;
	public string url_del_assetbundle_online;
	public static int intento=1;
	
	public bool usar_online;

	
	void Start(){

		if(usar_online==true){
			//online
			
		
		WWW www= new WWW(url_del_assetbundle_online);
		StartCoroutine(DownloadFile(url_del_assetbundle_online,nombre_del_prefab));
		}else{
			//LOCAL:
			/*
			va a la carpeta que le dijiste donde tienes guardado el assetbundle
			lo toma y lo instancia como objeto en la escena
			 */
			
			LoadAssetBudleMetodo(path_folder_de_donde_sale_el_assetbundle);
			InstantiateObjectFromBundle(nombre_del_prefab);
			//si se usa el ONLINE, no usar el LOCAL
			
		}
			}





//ONLINE
/*
cuando se quiere acceder a un archivo online se usa el siguiente metodo
le tienes que indicar la direccion url de donde esta el archivo y el nombre del asset
no se explicarlo bien, ya que lo copie y pegue en granparte de la documentacion de unity, pero
lo que hace es que toma la liga de donde esta el assetbundle (NO es .unity3d), lo descarga a una carpeta en tu ordenador o dispositivo
y lo instancia en la escena
 */
	IEnumerator DownloadFile(string wwws, string assetname) {
		Debug.Log("entrodownload!");
        var uwr = new UnityWebRequest(wwws, UnityWebRequest.kHttpVerbGET);
		Debug.Log("descargando de "+wwws);
        string pathx = Path.Combine(Application.persistentDataPath, "unity3dx");
		Debug.Log("path:"+pathx);
        uwr.downloadHandler = new DownloadHandlerFile(pathx);
        yield return uwr.SendWebRequest();
        if (uwr.isNetworkError || uwr.isHttpError)
            Debug.LogError(uwr.error);
        else
            Debug.Log("File successfully downloaded and saved to " + pathx);

	LoadAssetBudleMetodo(pathx);
	InstantiateObjectFromBundle(assetname);
    }

	void Update () {
		if(Input.GetKeyUp(KeyCode.P)){
			LoadAssetBudles.intento++;
			
		}
		}

		//ONLINE

	 
		
	
//LOCAL:
	void LoadAssetBudleMetodo(string bundleURL){


			myLoaderAssetbundle=AssetBundle.LoadFromFile(bundleURL);

			 //aqui te indica si pudo cargarlo o no
			Debug.Log(myLoaderAssetbundle == null ? "FAILED": "SUCCED!");
	}
	void InstantiateObjectFromBundle(string assetname){

				var prefab=myLoaderAssetbundle.LoadAsset(assetname);
				Instantiate(prefab);

	}

}
