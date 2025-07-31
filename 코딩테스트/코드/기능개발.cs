using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] progresses, int[] speeds) {
        List<int> answer = new List<int>();
        
        List<int> days = new List<int>();
        
        for (int i = 0; i < progresses.Length; i++)
        {
            int test = (int)Math.Ceiling((100-progresses[i]) / (double)speeds[i]);
            days.Add(test);
        }
        
        int num = 1;
        int groupStartDay = days[0];  // 핵심: 현재 그룹의 기준일
        
        for (int i = 0; i < days.Count - 1; i++)
        {
            if (groupStartDay >= days[i+1])  // 기준일과 비교
            {
                num++;
            }
            else
            {
                answer.Add(num);
                num = 1;
                groupStartDay = days[i+1];  // 새 그룹의 기준일 갱신
            }
        }
        answer.Add(num);
        
        return answer.ToArray();
    }
}