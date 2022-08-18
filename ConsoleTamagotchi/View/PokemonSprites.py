# -*- coding: utf-8 -*-
"""
author: vxgmichel
disponível em: https://gist.github.com/vxgmichel/80fca9bd3220f45e0fb2ea0d3167ccb3
"""

#!/usr/bin/env python3

import json
import time
import random
import shutil
import argparse
from urllib.request import Request, urlopen

from imageio import imread

UPPER_HALF_BLOCK = "\u2580"
LOWER_HALF_BLOCK = "\u2584"


def get_data(pid):
    url = f"http://pokeapi.co/api/v2/pokemon/{pid}"
    headers = {'User-Agent': 'Mozilla/5.0'}
    response = urlopen(Request(url, headers=headers))
    url = json.loads(response.read())["sprites"]["front_default"]
    response = urlopen(Request(url, headers=headers))
    return response.read()


def paint(color1, color2):
    r1, g1, b1, a1 = color1
    r2, g2, b2, a2 = color2
    if a1 == a2 == 0:
        print(f"\033[0m", end="")
        print(" ", end="")
    elif a1 == 0:
        print(f"\033[0m", end="")
        print(f"\033[38;2;{r2};{g2};{b2}m", end="")
        print(LOWER_HALF_BLOCK, end="")
    elif a2 == 0:
        print(f"\033[0m", end="")
        print(f"\033[38;2;{r1};{g1};{b1}m", end="")
        print(UPPER_HALF_BLOCK, end="")
    else:
        print(f"\033[38;2;{r1};{g1};{b1}m", end="")
        print(f"\033[48;2;{r2};{g2};{b2}m", end="")
        print(UPPER_HALF_BLOCK, end="")


def main(pid=None):
    if pid is None:
        pid = random.randint(1, 1)
    data = imread(get_data(pid))
    width, height = shutil.get_terminal_size((80, 60))
    for first_row, second_row in zip(data[0::2], data[1::2]):
        for _, first, second in zip(range(width), first_row, second_row):
            paint(first, second)
        print(f"\033[0m")


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description='Pokemon sprites in terminal')
    parser.add_argument('--pid', '-p', metavar='PID', type=int)
    parser.add_argument('--loop', '-l', action="store_true")
    args = parser.parse_args()
    main(args.pid)
    while args.loop:
        time.sleep(1)
        main()