# Créer un Neural Network via ML Agent

## Étape 1 : Setup

* Placer le fichier ML-Agent, copié à partir du [lien](https://github.com/Unity-Technologies/ml-agents/tree/latest_release) dans les **Assets** de votre projet Unity.  
* Créer une **Academy**dans la hierarchie de notre Scene (représentant l'environement dans notre construction de reinforcement learning) auquel on accrochera le **script de type Academy**  
* Sur ce qui sera notre agent, ajouter les composants **Behaviour Parameters** et le **script de type Agent** (comprenant les actions possibles de notre agent et ses key trigger en controle Heuristic)   
* Sous le folder .config de ML-Agent, créer un fichier .yaml contenant les hyperparameters optimisés à votre cas.  


### Étape 2 : Lancer le training de l'agent

* Sur un terminal, depuis l'Asset ML-Agent (afin d'accéder au folder .config) lancer  
```
mlagents-learn config/<notre-fichier-config>.yaml --run-id=<id-du-training> --train {--option: --env=<lien_vers_le_fichier_.app_permet_de_ne_pas_lancer_le_training_depuis_línterface_unity>  --load (si l'id a déjà été lancée, le neural network repartira de ses dernières performances)}
```
 
* Pour suivre l'apprentissage depuis Tensorboard :  
```
tensorboard --logdir=summaries --port=6006  
```
[localhost:6006](localhost:6006)

### Étape 3 : Visualiser les résultats

Depuis Unity, importer le modèle et son neural network approprié dans le folder Assets.  
Drag & Drop le fichier .nn sur le composant **Behaviour Parameters** de l'agent (sous Model).
Lancer la scene via Play.
