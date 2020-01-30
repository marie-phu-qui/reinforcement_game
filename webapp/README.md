# Deploiment sur Azure   

## Étape 0 : Ressources nécessaires

* Création d'un ressource group

Exemple : Location : France(Paris) = francecentral  
 
```
az group create -l <location-name> -n <resource-group-name>
```

* Création d'un storage account (possiblement non nécessaire)

Sur le powershell avec [AZURE CLI](https://docs.microsoft.com/fr-fr/cli/azure/install-azure-cli?view=azure-cli-latest).  

```
az storage account create  --name <storageaccountname>   --resource-group <ressource_groupe_name>   --location francecentral   --sku Standard_RAGRS    --kind StorageV2
```

=======

## Étape 1 : Activer l'application localement  


Sous le répertoire contenant l'application web (application.py)  
Lancer l'application en local avec ses packages nécessaires.  
 

* exemple : sous une application type flask - sous Windows (dans git bash)  

```  
python -m venv venv  
venv/Scripts/activate  
pip install -r requirements.txt  
export FLASK_APP=application.py  
flask run  
```  

## Étape 2 : S'identifier sur le CLI Azure  

Installer l'interface de commandes [AZURE CLI](https://docs.microsoft.com/fr-fr/cli/azure/install-azure-cli?view=azure-cli-latest).  

* sous Windows : lancer un Powershell en administrateur et se connecter à son compte Azure (devrait nous rediriger vers la page credentials)

```  
az.cmd login  
```  

## Étape 3 : Deployer pour la première fois l'application  

* En France (Paris) <location-name> = francecentral. Nécessité d'être sous le répertoire "requirements.txt" (sous python) ou package.json, sever.js, index.js (node.js).

```
az webapp up -n <app-name> -l <location-name> -p <plan-name>
```

Cette commande crée un Ressource Group, un App Service Plan et déploie sur un lien du type http:// <app-name> .azurewebsites.net  


## Étape FINAL : Supprimer le groupe de ressource si on souhaite définitivement supprimer les coûts de l'application

```az group delete -n <ressource-group-name>  ```
