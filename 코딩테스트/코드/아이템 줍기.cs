using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int[,] rectangle, int characterX, int characterY, int itemX, int itemY) {
        // 좌표를 2배로 확대 (테두리 문제 해결을 위해)
        int[,] map = new int[101, 101];  // 50*2 + 1

        // 사각형들을 맵에 표시
        for (int i = 0; i < rectangle.GetLength(0); i++) {
            int x1 = rectangle[i, 0] * 2;
            int y1 = rectangle[i, 1] * 2;  
            int x2 = rectangle[i, 2] * 2;
            int y2 = rectangle[i, 3] * 2;

            // 사각형 내부와 테두리 표시
            for (int x = x1; x <= x2; x++) {
                for (int y = y1; y <= y2; y++) {
                    if (map[x, y] == 1) continue;  // 이미 내부로 표시된 곳은 건드리지 않음

                    // 테두리인지 확인
                    if (x == x1 || x == x2 || y == y1 || y == y2) {
                        map[x, y] = 1;  // 테두리
                    } else {
                        map[x, y] = 2;  // 내부
                    }
                }
            }
        }

        // 다른 사각형의 내부에 있는 테두리는 내부로 변경
        for (int i = 0; i < rectangle.GetLength(0); i++) {
            int x1 = rectangle[i, 0] * 2;
            int y1 = rectangle[i, 1] * 2;
            int x2 = rectangle[i, 2] * 2;
            int y2 = rectangle[i, 3] * 2;

            for (int x = x1 + 1; x < x2; x++) {
                for (int y = y1 + 1; y < y2; y++) {
                    map[x, y] = 2;  // 내부
                }
            }
        }

        // BFS로 최단거리 찾기
        Queue<(int x, int y, int distance)> queue = new Queue<(int, int, int)>();
        bool[,] visited = new bool[101, 101];
        int[,] directions = {{0, 1}, {0, -1}, {-1, 0}, {1, 0}};

        // 시작점도 2배로 확대
        int startX = characterX * 2;
        int startY = characterY * 2;
        int endX = itemX * 2;
        int endY = itemY * 2;

        queue.Enqueue((startX, startY, 0));
        visited[startX, startY] = true;

        while (queue.Count > 0) {
            var (x, y, dist) = queue.Dequeue();

            // 목표점 도달
            if (x == endX && y == endY) {
                return dist / 2;  // 2배로 확대했으므로 다시 나누기 2
            }

            // 4방향 탐색
            for (int i = 0; i < 4; i++) {
                int nx = x + directions[i, 0];
                int ny = y + directions[i, 1];

                // 범위 체크 및 이동 가능 여부 확인
                if (nx >= 0 && nx <= 100 && ny >= 0 && ny <= 100 
                    && map[nx, ny] == 1 && !visited[nx, ny]) {  // 테두리로만 이동

                    queue.Enqueue((nx, ny, dist + 1));
                    visited[nx, ny] = true;
                }
            }
        }

        return -1;  // 도달 불가능
    }
}
