#include<stdio.h>
#include<stdlib.h>
#include<math.h>
#include<stdbool.h>
#define PI 3.14159265
#define NUMBER 1000000
#define N 3




double factorial(int x){
	double m=1;
	if(x==0 || x==1)
		return 1;
	else{
		for(int n=1;n<=x;n++)
			m*=(double)n;
		return m;
	}
}

double power(double x,int y){
	double sum = 1;
	if(y == 0)
		return 1;
	else{
		for(int a=0;a<y;a++)
			sum*=x;
		return sum;
	}
}

double sign(int n){
	if(n % 2 == 0)
		return 1;
	else
		return -1;
} 




void average(double *tab,double *tab1){
        double sum=0;
        int count=0;
        for(int z=0;z<NUMBER;z++){
                sum+=*(tab+z);
                if((z+1) % 50000 == 0){
                        *(tab1+count)=sum/50000;
                         sum=0;
                         count++;
                }
        }
}



double sum1(int n,double *tab){
	double sum=0;
	for(int a=0;a<n;a++)
		sum+=(*(tab+a));
	return sum;
}

double sum2(int n,double *tab){
	double sum=0;
	for(int a=n-1;0<=a;a--)
		sum+=(*(tab+a));
	return sum;
}
		
		
void cosTaylor(double x,double step,bool direction,double *tab){
	double sum=0.0;
	double r=x;
	double radian=0.0;
	double summath=0.0;
	if(direction){
		for(int z=0;z<NUMBER;z++){
			sum=0.0;
			r=r+step;
			radian = r * (PI/180.0);
			summath = cos(radian);
			for(int a=0;a<N;a++){
				sum+=(power(radian,2*a)/factorial(2*a)) * sign(a);
			}
			*(tab+z)=fabs(summath-sum);
		}
	}
	else{
		for(int z=0;z<NUMBER;z++){
			sum=0.0;
			r = r + step;
			radian = r * (PI/180.0);
			summath=cos(radian);
			for(int a=N-1;a>=0;a--){
				sum+=(power(radian,2*a)/factorial(2*a)) * sign(a);
			}
			*(tab+z)=fabs(summath-sum);
		}
	}
	
}


void cosQ(double x,double step,double *small,double *large1,double *large2){
	double r=x;
	double radian=0.0;
        double q=1.0;
        double summath=0.0;
	int count=1;
        for(int z=0;z<NUMBER;z++){
		r = r + step;
		radian= r * (PI/180.0);
                summath = cos(radian);
                q=1.0;
		count=1;
		*(small)=1.0;
		for(double a=0;a<N-1;a++){
			q*=(-radian*radian)/(4*a*a+6*a+2);
			*(small+count)=q;
			 count++;
		}
	
	*(large1+z)=fabs(summath - sum1(N,small));
	*(large2+z)=fabs(summath - sum2(N,small));
	}
}

double cosTaylorN(bool direction,double n){
	double sum=0.0;
	double radian=0.0;
	double summath=0.0;
	if(direction){
			radian = 0.5 * (PI/180.0);
			summath = cos(radian);
			for(double a=0;a<n;a++){
				sum+=(power(radian,2*a)/factorial(2*a)) * sign(a);
			}
			return fabs(summath-sum);
	}
	else{
		
			radian = 0.5 * (PI/180.0);
			summath=cos(radian);
			for(double a=n-1;a>=0;a--){
				sum+=(power(radian,2*a)/factorial(2*a)) * sign(a);
			}
			return fabs(summath-sum);
		
		}
}
		
		
			

void main(){
        FILE *fp;
        char buffer[100];
        double *small = (double *)malloc(N*sizeof(double));
        double *medium1 = (double *)malloc(20*sizeof(double));
	double *medium2 = (double *)malloc(20*sizeof(double));
	double *large1 = (double *)malloc(NUMBER * sizeof(double));
	double *large2 = (double *)malloc(NUMBER * sizeof(double));

	
	cosTaylor(0,0.000001,true,large1);
	average(large1,medium1);
	cosTaylor(0,0.000001,false,large2);
	average(large2,medium2);
	fp = fopen("cosTaylorLeft.csv","w");
	fputs("X,cosTaylorLeft \n",fp);
        for(int a=0;a<20;a++){
                sprintf(buffer,"%d,%.50lf \n",a,*(medium1+a));
                fputs(buffer,fp);
        }
        fclose(fp);
	fp = fopen("cosTaylorRight.csv","w");
	fputs("X,cosTaylorRight \n",fp);
	for(int a=0;a<20;a++){
        	sprintf(buffer,"%d,%.50lf \n",a,*(medium2+a));
                fputs(buffer,fp);
        }
        cosQ(0,0.000001,small,large1,large2);
        average(large1,medium1);
	average(large2,medium2);
        fp = fopen("cosQLeft.csv","w");
	fputs("X,cosQLeft \n",fp);
        for(int a=0;a<20;a++){
                sprintf(buffer,"%d,%.50lf \n",a,*(medium1+a));
                fputs(buffer,fp);
        }
        fclose(fp);
	fp = fopen("cosQRight.csv","w");
	fputs("X,cosQRight \n",fp);
	for(int a=0;a<20;a++){
        	sprintf(buffer,"%d,%.50lf \n",a,*(medium2+a));
                fputs(buffer,fp);
        }
	fclose(fp);
	fp = fopen("cosTaylorN.csv","w");
	fputs("X,cosTaylorLeftN,cosTaylorRightN \n",fp);
	for(double n=1.0;n<10;n++){
		sprintf(buffer,"%lf,%.20lf,%.20lf \n",n,cosTaylorN(true,n),cosTaylorN(false,n));
		fputs(buffer,fp);
	}
	fclose(fp);
        free(small);
        free(medium1);
	free(medium2);
	free(large1);
	free(large2);

}



