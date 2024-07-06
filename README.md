# Blazor Server App K8 Deployment
This tutorial will guide you through the process of deploying a Blazor server app on Kubernetes, addressing common pitfalls and providing solutions for running blazor server apps behind a load balancers. The directory structure includes YAML files for deployments, namespaces, persistent storage, secrets, and configurations for Redis backplane and sticky sessions.

## Prerequisites
* Kubernetes cluster (Docker Desktop,minikube, GKE, EKS, etc.)
*  `kubectl` CLI tool configured to interact with your cluster
*  Basic knowledge of Kubernetes concepts

## Steps

### 1. Build Docker image
In this step, we'll use the docker build command to create a Docker image for our Blazor Weather App.
```shell
docker build -f .\src\WeatherApp\Dockerfile . -t blazor-k8-deployment/weather-app:latest
```

### 2. Set Up Namespace 
Create a namespace for your Weather App to isolate it from other applications:
```shell
kubectl apply -f deployment/weatherapp-namespace.yaml
kubectl config set-context --current --namespace=weather-app 
```

### 3. Create Secrets
Create secrets for storing sensitive information:
```shell
kubectl apply -f deployment/weatherapp-secret.yaml 
```

### 4. Configure Persistent Storage
Set up persistent storage for your WeatherApp:
```shell
kubectl apply -f deployment/weatherapp-persistent.yaml
```

### 5. Deploy Weather App
Deploy the main application using the deployment file:
```shell
kubectl apply -f deployment/weatherapp-deployment.yaml
```

### 6. Set Up NGINX Ingress Controller
To manage Ingress resources, set up the NGINX Ingress Controller:

**Minikube**

If you are using minikube, enable the ingress addon:
```shell
minikube addons enable ingress
```

**Other Environments**

For other environments, apply the mandatory resources for NGINX Ingress Controller:
```shell
kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/main/deploy/static/provider/cloud/deploy.yaml
```

Wait for the NGINX Ingress Controller pods to be up and running:
```shell
kubectl get pods --namespace ingress-nginx
```
If you want to access the ingress controller locally, you can set up port forwarding:

```shell
kubectl -n ingress-nginx --address 0.0.0.0 port-forward svc/ingress-nginx-controller 80
```

### 7. Apply Ingress Configuration
Apply the ingress configuration for your Blazor Server app:
```shell
kubectl apply -f deployment/weatherapp-ingress.yaml
```

### 8. Configuration

#### 1. Configure Weather App to use only Sticky Session
Navigate to the `sticky-session` directory and apply the configuration files:

```shell
cd deployment/sticky-session
kubectl apply -f weatherapp-configmap.yml
```

#### 2. Configure Weather App to use Redis as a Backplane

Navigate to the `redis` directory and apply the configuration files:

```shell
cd deployment/redis
kubectl apply -f weatherapp-configmap.yaml
kubectl apply -f weatherapp-redis.yaml
```

### 9 File Descriptions

* `weatherapp-namespace.yaml`: Defines the namespace for the WeatherApp.
* `weatherapp-secret.yaml`: Stores sensitive information like database passwords.
* `weatherapp-persistent.yaml`: Configures persistent storage for the application.
* `weatherapp-deployment.yaml`: Manages the deployment of the WeatherApp.
* `weatherapp-ingress.yaml`: Manages ingress for the weather app.
* `redis/weatherapp-configmap.yaml`: Configures the Redis setup for the WeatherApp.
* `redis/weatherapp-redis.yaml`: Deploys the Redis instance.
* `sticky-session/weatherapp-configmap.yaml`: Configures sticky session settings.

### 10. Test the Application
To test if the application is properly set up, you can use curl to send a request and verify the response. If the response status is 200, return an error:
```shell
response=$(curl --location -s -o /dev/null -w "%{http_code}" 'http://weather-app.local/')

if [ "$response" -eq 200 ]; then
  echo "Error: Received status 200"
  exit 1
else
  echo "Success: Received status $response"
fi
```


### 11. Clean up
To remove the WeatherApp from your cluster, delete the resources in reverse order
```shell
cd deployment
kubectl delete -f sticky-session/weatherapp-configmap.yaml
kubectl delete -f redis/weatherapp-redis.yaml
kubectl delete -f redis/weatherapp-configmap.yaml
kubectl delete -f weatherapp-ingress.yaml
kubectl delete -f weatherapp-deployment.yaml
kubectl delete -f weatherapp-persistent.yaml
kubectl delete -f weatherapp-secret.yaml
kubectl config set-context --current --namespace=default
kubectl delete -f weatherapp-namespace.yaml
```

##  Conclusion
This tutorial covers the deployment of a Blazor Server App on Kubernetes and common issues and fixes for running Blazor Server Apps with load balancers. [Read the blog]().