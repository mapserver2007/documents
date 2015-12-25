using System.Collections.Generic;

namespace DesignPattern.DoubleDispatch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program.OverloadSample();
            Program.DoubleDispatchSample();
        }

        private static void OverloadSample()
        {
            // Overload
            Overload a = new Overload();
            // ポリモーフィズム(オーバーロード)の性質により渡されるオブジェクトによって振る舞いが変わる
            // 振り分け係(Dispatcher)にオブジェクトを渡して処理を委譲する
            a.execute(new Dog()); // dog
            a.execute(new Cat()); // cat

            // ただし、この場合はコンパイルエラーとなる
            // オーバーロードは静的に評価されるため、実行時までオブジェクトの型が確定されない
            IAnimal animal = new Dog();
            //a.execute(animal); // コンパイルエラー

            List<IAnimal> list = new List<IAnimal>();
            list.Add(new Dog());
            list.Add(new Cat());
            list.ForEach(o =>
            {
                // ポリモーフィズムだとこういうことができない
                //a.execute(o);
            });
        }

        private static void DoubleDispatchSample()
        {
            DoubleDispatch a = new DoubleDispatch();
            // ダブルディスパッチではポリモーフィズム(オーバーロード)と呼び出し方が逆になる
            // 実行者はオブジェクト自身になり、そのオブジェクトに振り分け係(Dispatcher)を渡す
            // オブジェクト内部でDispatcherを受け取ってその中で委譲する
            // ディスパッチが2回走るのでダブルディスパッチと呼ぶ
            new Bird().execute(a);
            new Rabbit().execute(a);
            // オーバーロードだとエラーになっていたこういうのができるようになる
            IAnimal2 animal = new Bird();
            animal.execute(a);
            // このパターンの最大の利点は、異なる型をリストに詰めて一気に回す場合
            List<IAnimal2> list = new List<IAnimal2>();
            list.Add(new Bird());
            list.Add(new Rabbit());

            list.ForEach(o =>
            {
                // 単にオーバーロードを使ったやり方だとこれができない
                o.execute(a);
            });
        }
    }
}
