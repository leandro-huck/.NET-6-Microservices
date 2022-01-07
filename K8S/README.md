# K8S
Contains yaml files to apply in Kubernetes

## Deploying ingress controller
https://kubernetes.github.io/ingress-nginx/deploy/

##### Get pods info
kubectl get pods --namespace=ingress-nginx

##### Get events log
kubectl get events --all-namespaces  --sort-by='.metadata.creationTimestamp'

## Command execution 
- kubectl apply -f 01-platform-depl.yaml
- kubectl apply -f 02-command-depl.yaml
- kubectl apply -f 03-platform-nodeport-srv.yaml
- kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.1.0/deploy/static/provider/cloud/deploy.yaml
- kubectl apply -f 04-ingress-srv.yaml