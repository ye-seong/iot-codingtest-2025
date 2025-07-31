#include <string>
#include <vector>
#include <algorithm>
using namespace std;

int solution(vector<int> wallet, vector<int> bill) {
    int answer = 0;
    
    while (true) {
        // wallet과 bill의 최소값, 최대값 구하기
        int wallet_min = min(wallet[0], wallet[1]);
        int wallet_max = max(wallet[0], wallet[1]);
        int bill_min = min(bill[0], bill[1]);
        int bill_max = max(bill[0], bill[1]);
        
        // 지갑에 들어갈 수 있는지 확인
        if (bill_min <= wallet_min && bill_max <= wallet_max) {
            break;
        }
        
        // 긴 쪽을 반으로 접기
        if (bill[0] >= bill[1]) {
            bill[0] = bill[0] / 2;  // 정수 나눗셈으로 소수점 버림
        } else {
            bill[1] = bill[1] / 2;  // 정수 나눗셈으로 소수점 버림
        }
        
        answer++;
    }
    
    return answer;
}