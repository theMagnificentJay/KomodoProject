# KomodoProject
![GitHub code size in bytes](https://img.shields.io/github/languages/code-size/theMagnificentJay/KomodoProject)
![Lines of code](https://img.shields.io/tokei/lines/github.com/theMagnificentJay/KomodoProject)
![GitHub top language](https://img.shields.io/github/languages/top/theMagnificentJay/KomodoProject)

Komodo Project is a final assessment for Gold Badge in the software development course at [Eleven Fifty Academy](https://elevenfifty.org/). It contains three challenges, the KomodoCafe, KomodoClaims, and KomodoBadges.

## Installation

Using a terminal of your choice with [**git**](https://git-scm.com/) installed, run the following command to clone the repository into a directory you have created.

```bash
git clone https://github.com/theMagnificentJay/KomodoProject.git
```

## Structure
Komodo Project is divided into three solution folders, '*_Run*', '*KomodoAssemblies*', and '*KomodoTests*'.

The *'_Run'* folder holds the initial ui with four options: '*KomodoCafe*', '*KomodoClaims*', '*KomodoBadges*', and '*Exit*'. Rather having the user set each assembly as a startup project, they can just set *'_00_KomodoRun'* as the startup project to access all three assemblies.

![img](https://github.com/theMagnificentJay/KomodoProject/blob/main/img/runui.png?raw=true)
Each ui is nested in its own while loop, so when you exit one you return to the original menu, exit the '*_00_KomodoRun*' and you exit the application completely. This hopefully adds some ease of access to the user.


## Project Status
![GitHub last commit](https://img.shields.io/github/last-commit/theMagnificentJay/KomodoProject)
![GitHub commit activity](https://img.shields.io/github/commit-activity/m/theMagnificentJay/KomodoProject)

While the project is due 05/20/2021, once I finish my current course and when time allows I plan on refactoring old projects to continue my learning and skills. You can track the latest commits with the shield.io badge in this section.


## Author
[![github](https://img.shields.io/badge/GitHub-theMagnificentJay-10?style=flat&logo=GitHub&logoColor=white)](https://github.com/theMagnificentJay)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-theMagnificentJay-0000ff?style=flat&logo=LinkedIn&logoColor=white)](https://github.com/theMagnificentJay)
[![portfolio](https://img.shields.io/badge/Portfolio-theMagnificentJay-000000?style=flat&logo=data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAAhQAAAIUB4uz/wQAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAS1SURBVEiJhZVtTJVlGMd/9/Och3OAA4gpigKJTl3Zgsah6UzDkaJALr/0pTlqtXyJVas2N1mr5kvp1rQs0EVLG622Vk2TzSO6pmtWCk5MExlG8wWRN6ceOC/Py9WHwwGPB+T69tzX/fz/9/W/3pSIMJ4Fysqy+g3jmdqQVF9ynKK7aN50l0sKDXV1nsipVcr60W1Zf3j9/p7xMNSYBD6fEcrOrrnpyOaqgGkEBFKTU9A0Le7ak8rhA802vWJv89y6tZ3mZnNCgsGKikJNqf2tDgVvBiJYSrGytITiokKypkwmHI7Q1t7B+QttXLrcQQ7CVt1kOtLqiLyc2th4blyCcGXlRoHdPYLxwt0wGekZ7Nz2PrPycpiUnoJSKu4xR5pOUFvfgHtwkHo9QiqYCt52Hz5cm0AwWFFRqCt1GjBeGbLp1HV++GYvGWle0rye8STm6rUu1r9VQ7kZZL1mAZi2yNOxSLSY5ppS+wHjhCX8EzH55MMa3Enuh4ID5OXO4NWqFzkoOp2iAKJYPp8xQhDKzq5RUACwI2ST/2guc2bnTwgeszWrV5I5OZN6cUVlgYLQtGmbAbRAWVkWIpsBhoB+y+LZxYsAMFwa/mMnqatv4EZX9wjgja5u6uob8B87iYigKcX8ufmcE42RMlKqJlBWluUyDKNYwADwD3ufeHw+mqY403Kenbv3AfD3xcvU7toCwNadX9De0QlARkYaC4ufYs7sWZz66yztorFAOQCGYRjFmoj4YqSnbAcA2xFEoLd/YOTVff0DiAgiQv/A7ZHz3r7onUgkAsBFRitNRHyaQFHs4D87WlFXrnQiIixbuoiSJQvJy51J9boqlFIopaheV0Ve7kxKliyktGQxANeudwHwr4w2o0CRClZUdAHZABuCDmfDER6ZlMmBr/aQlurBmzpxonv6+ln72jtYlsVqZfNGtFwBbsb1/mOu6GdgcJAjR4/T23+btvYrAFi2g+MIjiNYw1JeutxBy7kLfLnvWywrCpqj4ieDGiovP6SUeh6gSxRr7gTRdZ20FC+O4zAYGuJA3adgeJg6OSOq+8AdMENUbXiXVM/ojNKB7/QImUgsB79qClpibDOUMDfJwLZtTMtE0zTSUryEwxFEoqIiIALhcIS0FG/cACxV9gg4gIIWl1Kq+f6g6pJ1Ki2bYCiEK9WFUoqfD/lZvnwZvbeivaDpLpqafouTIl8J1aPaRwmUalb3VqzIchnGdYZ7AeB3W3jvXhjDSCLFk/xgThPMC+zRI8wgTn/TMs0czev396DUdgAb2BIWPhqyECBiRhgKDU1IEAT2OC4aRR+lENnm9ft7otPU5zOC06ef2Rh0Cs6GIwkAhssgxZOcMK7HspeUzVrNak3u7i6mudmMZqi52fzY5POxwIdj5d5gANNKWFgJ9r3o/IReE9tucQtn/fLKY3+GwqUP29NpKV50XR/Tp4BVmtOwqfGXtbGzuEbb23T4uQUe9y5daQk/A7iT3OOCpyJWgXI23Q+eEEHMViyrKBSkqc8ypzjD/ljzPWg6MA+n1bSd8q+PHuxKiOphcuxauXrBadvZccO0l3oNw+W4XB6AdEUgGbqn4hyfZzufve4/1DYexv8B5Rc7939RLgAAAABJRU5ErkJggg==&logoColor=white)](https://github.com/theMagnificentJay)

## Credit

[**makeareadme**](makeareadme.com), [**shields.io**](shields.io), [**Base 64 Image**](https://www.base64-image.de/), and [**Freepik**](freepik.com)
