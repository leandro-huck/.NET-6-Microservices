# K8S
Contains yaml files to apply in Kubernetes

## Deploying ingress controller
https://kubernetes.github.io/ingress-nginx/deploy/

##### Get pods info
kubectl get pods --namespace=ingress-nginx

##### Get events log
kubectl get events --all-namespaces  --sort-by='.metadata.creationTimestamp'

## Command execution 
- kubectl apply -f local-pvc.yaml
- kubectl create secret generic <secretKeyRef Name> --from-literal=SA_PASSWORD="<pwd>"
- kubectl apply -f mssql-platform-depl.yaml
- kubectl apply -f platform-depl.yaml
- kubectl apply -f command-depl.yaml
- kubectl apply -f platform-nodeport-svc.yaml
- kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.1.0/deploy/static/provider/cloud/deploy.yaml
- kubectl apply -f ingress-svc.yaml
- kubectl apply -f rabbitmq-depl.yaml