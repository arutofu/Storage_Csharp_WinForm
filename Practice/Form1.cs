using dataTree;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Main
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public TreeData.TreeRoot tree = new TreeData.TreeRoot();
        public HashData[] hashdata = new HashData[GlobalVariables.hashMaxSize];

        void HashSizeFromTXT()
        {
            int counter123 = 0;
            using (StreamReader newline = new StreamReader(GlobalVariables.hashfilepath, Encoding.UTF8))
            {
                String line;
                while ((line = newline.ReadLine()) != null)
                {
                    counter123++;
                }
                GlobalVariables.hashsize = counter123;
            }
        }

        void TreeSizeFromTXT()
        {
            int counter321 = 0;
            using (StreamReader newline = new StreamReader(GlobalVariables.treefilepath, Encoding.UTF8))
            {
                String line;
                while ((line = newline.ReadLine()) != null)
                {
                    counter321++;
                }
                GlobalVariables.treesize = counter321;
            }
        }

        void FirstHashToTxt(ref HashData[] hashData)
        {
            FileStream fs = new FileStream(GlobalVariables.hashfilepath, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs, Encoding.UTF8);
            int counter = 0;
            for (int i = 0; i < GlobalVariables.hashMaxSize; i++)
            {
                if (hashData[i].Empty == false)
                {
                    writer.Write(hashData[i].Post);
                    writer.Write('/');
                    writer.Write(hashData[i].Phone);
                    writer.Write('/');
                    writer.Write(hashData[i].Kat);

                    if ((counter == GlobalVariables.hashsize - 1) == false)
                    writer.Write('\n');

                    counter++;
                }
            }
            writer.Close();
        }

        void FirstTreeToTxt(ref TreeData.TreeRoot treeData)
        {
            FileStream fs = new FileStream(GlobalVariables.treefilepath, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs, Encoding.UTF8);

            writer.Write(treeData.Tovar);
            writer.Write('/');
            writer.Write(treeData.Post);
            writer.Write('/');
            writer.Write(treeData.Obiem);
            writer.Close();

            if (treeData.Left != null)
                SecondTreeToTxt(ref treeData.Left);
            if (treeData.Right != null)
                SecondTreeToTxt(ref treeData.Right);
        }

        void SecondTreeToTxt(ref TreeData.TreeRoot treeData)
        {
            FileStream fs = new FileStream(GlobalVariables.treefilepath, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs, Encoding.UTF8);
            writer.Write('\n');
            writer.Write(treeData.Tovar);
            writer.Write('/');
            writer.Write(treeData.Post);
            writer.Write('/');
            writer.Write(treeData.Obiem);
            writer.Close();

            if (treeData.Left != null)
                SecondTreeToTxt(ref treeData.Left);
            if (treeData.Right != null)
                SecondTreeToTxt(ref treeData.Right);
        }

        void TreeToForm(ref TreeData.TreeRoot treeData)
        {
            GridTovar.Rows[GlobalVariables.gridCounter].Cells[0].Value = GlobalVariables.gridCounter + 1;
            GridTovar.Rows[GlobalVariables.gridCounter].Cells[1].Value = treeData.Tovar;
            GridTovar.Rows[GlobalVariables.gridCounter].Cells[2].Value = treeData.Post;
            GridTovar.Rows[GlobalVariables.gridCounter].Cells[3].Value = treeData.Obiem;

            GlobalVariables.gridCounter++;

            if (treeData.Left != null)
                TreeToForm(ref treeData.Left);
            if (treeData.Right != null)
                TreeToForm(ref treeData.Right);
        }

        void HashToForm(ref HashData[] hashData)
        {
            int counter = 0;
            for (int i = 0; i < GlobalVariables.hashMaxSize; i++)
            {
                if (hashData[i].Empty == false)
                {
                    GridPost.Rows[counter].Cells[0].Value = counter + 1;
                    GridPost.Rows[counter].Cells[1].Value = hashData[i].Key;   // hashData[i].Key;          Hash1(hashData[i].Post)
                    GridPost.Rows[counter].Cells[2].Value = hashData[i].Post;
                    GridPost.Rows[counter].Cells[3].Value = hashData[i].Phone;
                    GridPost.Rows[counter].Cells[4].Value = hashData[i].Kat;
                    counter++;
                }
            }
        }

        void TreeMinus(ref TreeData.TreeRoot treeData, string strTovar, int intObiem)
        {
            if (treeData.Tovar != strTovar)
            {
                if (treeData.Tovar.CompareTo(strTovar) == 1)
                {
                    TreeMinus(ref treeData.Left, strTovar, intObiem);
                }
                else 
                if (treeData.Tovar.CompareTo(strTovar) == -1 || treeData.Tovar.CompareTo(strTovar) == 0)
                {
                    TreeMinus(ref treeData.Right, strTovar, intObiem);
                }
            }
            if (treeData.Tovar == strTovar)  // ---------------------------  ЕСЛИ ОБЪЕМ == 0 ТО УДАЛИТЬ УЗЕЛ
            {
                treeData.Obiem -= intObiem;
                if (treeData.Obiem < 1)
                {
                    DelMinRight(ref treeData);
                }
            }
        }

        void DelMinRight(ref TreeData.TreeRoot treeData)
        {
            TreeData.TreeRoot del = treeData;
            TreeData.TreeRoot min = null;
            TreeData.TreeRoot prev = null;

            if (treeData.Left == null && treeData.Right == null && treeData.Parent == null)  // ПУСТОЙ КОРЕНЬ
            {
                treeData = null;
            }
            else
            {
                min = treeData;
                if (treeData.Parent == null)   // НЕ ПУСТОЙ КОРЕНЬ
                {
                    if (min.Right != null)   // ПРАВЫЙ ЕСТЬ 
                    {
                        min = min.Right;
                        if (min.Left != null)  // ЛЕВЫЙ ПРАВОГО ЕСТЬ 
                        {
                            while (min.Left != null)  // ИЩЕМ MIN  
                            {
                                min = min.Left;
                            }
                            if (min.Right != null) // У MIN ЕСТЬ ПРАВЫЙ  
                            {
                                prev = min.Parent;
                                
                                prev.Left = min.Right;
                                prev.Left.Parent = prev;

                                min.Right = del.Right;
                                min.Right.Parent = min;

                                min.Left = del.Left;
                                min.Left.Parent = min;

                                del = min;

                                min = null;

                                min.Root = min;
                            }
                            else  // У MIN НЕТ ПОТОМКОВ   
                            {
                                prev = min.Parent;
                                
                                min.Right = del.Right;
                                min.Right.Parent = min;

                                min.Left = del.Left;
                                min.Left.Parent = min;

                                treeData = min;

                                prev.Left = null;
                                min.Parent = null;
                                min.Root = min;

                                min = null;
                            }
                        }
                        else  // ЛЕВОГО У ПРАВОГО НЕТ   
                        {
                            min.Parent = del.Parent;
                            min.Left = del.Left;
                            min.Left.Parent = min;
                            del = min;
                            min = null;
                        }
                    }
                    else  // ИНАЧЕ ЕСТЬ ЛЕВЫЙ
                    {
                        treeData = treeData.Left;
                        treeData.Left.Parent = treeData;
                    }
                }
                else
                {
                    if (del.Tovar.CompareTo(del.Parent.Tovar) > 0)  // del > parent  
                    {
                        if (min.Right != null)   // ПРАВЫЙ ЕСТЬ 
                        {
                            min = min.Right;
                            if (min.Left != null)  // ЛЕВЫЙ ПРАВОГО ЕСТЬ 
                            {
                                while (min.Left != null)  // ИЩЕМ MIN  
                                {
                                    min = min.Left;
                                }
                                if (min.Right != null) // У MIN ЕСТЬ ПРАВЫЙ  
                                {
                                    prev = min.Parent;
                                    min.Parent = del.Parent;
                                    prev.Left = min.Right;
                                    prev.Left.Parent = prev;
                                    min.Right = del.Right;
                                    min.Right.Parent = min;
                                    min.Left = del.Left;
                                    min.Left.Parent = min;
                                    min.Parent.Right = min;
                                }
                                else  // У MIN НЕТ ПОТОМКОВ   
                                {
                                    prev = min.Parent;
                                    prev.Left = min;
                                    min.Parent = del.Parent;
                                    prev.Left = min.Right;
                                    min.Right = del.Right;
                                    min.Right.Parent = min;
                                    min.Left = del.Left;
                                    min.Left.Parent = min;
                                    min.Parent.Right = min;
                                    prev.Left = null;
                                }
                            }
                            else  // ЛЕВОГО У ПРАВОГО НЕТ   
                            {
                                min.Parent = del.Parent;
                                min.Parent.Right = min;

                                if (del.Left != null)
                                {
                                    min.Left = del.Left;
                                    min.Left.Parent = min;
                                }
                            }
                        }
                        else  // ПРАВОГО НЕТ
                        {
                            if (min.Left != null)  // ЛЕВЫЙ ЕСТЬ  
                            {
                                while (min.Left != null)  // ИЩЕМ MIN   
                                {
                                    min = min.Left;
                                }
                                if (min.Right != null)  // У MIN ЕСТЬ ПРАВЫЙ  
                                {
                                    prev = min.Parent;
                                    min.Parent = del.Parent;
                                    prev.Left = min.Right;
                                    prev.Left.Parent = prev;
                                    min.Left = del.Left;
                                    min.Left.Parent = min;
                                    min.Parent.Right = min;
                                }
                                else  // У MIN НЕТ ПОТОМКОВ   
                                {
                                    prev = min.Parent;
                                    min.Parent = del.Parent;
                                    min.Left = del.Left;
                                    min.Parent.Right = min;
                                    min.Left.Parent = min;
                                    prev.Left = null;
                                }
                            }
                            else   // НЕТ ЛИСТЬЕВ   
                            {
                                del.Parent.Right = null;
                            }
                        }
                    }
                    if (del.Tovar.CompareTo(del.Parent.Tovar) < 1)  // del < = parent
                    {
                        min = treeData;
                        if (min.Right != null)   // ПРАВЫЙ ЕСТЬ   
                        {
                            min = min.Right;
                            if (min.Left != null)  // ЛЕВЫЙ ПРАВОГО ЕСТЬ   
                            {
                                while (min.Left != null)  // ИЩЕМ MIN   
                                {
                                    min = min.Left;
                                }
                                if (min.Right != null) // У MIN ЕСТЬ ПРАВЫЙ   
                                {
                                    prev = min.Parent;
                                    min.Parent = del.Parent;
                                    prev.Left = min.Right;
                                    prev.Left.Parent = prev;
                                    min.Right = del.Right;
                                    min.Right.Parent = min;
                                    min.Left = del.Left;
                                    min.Left.Parent = min;
                                    min.Parent.Left = min;
                                }
                                else  // У MIN НЕТ ПОТОМКОВ   
                                {
                                    prev = min.Parent;
                                    prev.Left = min;
                                    min.Parent = del.Parent;
                                    prev.Left = min.Right;
                                    min.Right = del.Right;
                                    min.Right.Parent = min;
                                    min.Left = del.Left;
                                    min.Left.Parent = min;
                                    min.Parent.Left = min;
                                    prev.Left = null;
                                }
                            }
                            else  // ЛЕВОГО У ПРАВОГО НЕТ   
                            {
                                min.Parent = del.Parent;
                                min.Parent.Left = min;
                                min.Left = del.Left;
                                min.Left.Parent = min;
                            }
                        }
                        else  // ПРАВОГО НЕТ
                        {
                            if (min.Left != null)  // ЛЕВЫЙ ЕСТЬ 
                            {
                                while (min.Left != null)  // ИЩЕМ MIN  
                                {
                                    min = min.Left;
                                }
                                if (min.Right != null)  // У MIN ЕСТЬ ПРАВЫЙ   
                                {
                                    prev = min.Parent;
                                    min.Parent = del.Parent;
                                    prev.Left = min.Right;
                                    prev.Left.Parent = prev;
                                    min.Left = del.Left;
                                    min.Left.Parent = min;
                                    min.Parent.Left = min;
                                }
                                else  // У MIN НЕТ ПОТОМКОВ   ++++
                                {
                                    prev = min.Parent;
                                    min.Parent = del.Parent;
                                    min.Left = del.Left;
                                    min.Parent.Left = min;
                                    min.Left.Parent = min;
                                    prev.Left = null;
                                }
                            }
                            else   // НЕТ ЛИСТЬЕВ   ++++
                            {
                                del.Parent.Left = null;
                            }
                        }
                    }
                }
            }
        }

        bool TreePlus (ref TreeData.TreeRoot treeData, string strTovar, string strPost, int intObiem)
        {
            while (treeData.Left.Equals(null) && treeData.Right.Equals(null))
            {
                if (treeData.Tovar == strTovar && treeData.Post == strPost)
                {
                    treeData.Obiem += intObiem;
                    return true;
                }
                else
                {
                    if (treeData.Tovar.CompareTo(strTovar) == 1)
                    {
                        TreePlus(ref treeData.Left, strTovar, strPost, intObiem);
                    }
                    if (treeData.Tovar.CompareTo(strTovar) == -1 || treeData.Tovar.CompareTo(strTovar) == 0)
                    {
                        TreePlus(ref treeData.Right, strTovar, strPost, intObiem);
                    }
                }
            }
            return false;
        }

        void GridClear(ref DataGridView dataGridView)
        {
            while (dataGridView.Rows.Count > 1)
                for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                    dataGridView.Rows.Remove(dataGridView.Rows[i]);
        }

        int Hash1(string post)
        {
            return (GlobalVariables.hashMaxSize / post.Length);
        }

        void HashObhod()
        {
            if (hashdata.Equals(null) == false)
            {
                for (int i = 0; i < GlobalVariables.hashMaxSize; i++)
                {
                    if (hashdata[i].Empty == false)
                    {
                        GlobalVariables.hashsize++;
                    }
                }
            }
            else
                MessageBox.Show("Хеша не существует");
        }

        bool HashFindPost(string post)
        {
            int postCount = 0;
            int Place = Hash1(post);
        repeatmark:
            if (hashdata[Place].Post != post)  // если не совпало
            {
                while (hashdata[Place].Post != post && postCount < GlobalVariables.hashsize)  // пока не дойдем
                {
                    if (Place == GlobalVariables.hashMaxSize - 1)  // если это последний элемент
                    {
                        Place = 0;      // идем в начало
                        goto repeatmark;
                    }
                    Place++;  // иначе просто перейдем к следующей ячейке
                    postCount++;
                }
                if (hashdata[Place].Post != post)
                {
                    return false;
                }
            }
            return true;
        }

        void HashDelete(ref HashData[] hashData, string post)
        {
            for (int i = 0; i < GlobalVariables.hashMaxSize; i++)
            {
                if (hashData[i].Empty == false && hashData[i].Post == post)
                {
                    hashData[i].Post = null;
                    hashData[i].Phone = null;
                    hashData[i].Kat = 0;
                    hashData[i].Empty = true;
                    hashData[i].Deleted = true;
                }
            }
        }

        public void HashInsert(ref HashData[] hashData, string post, string phone, int kat)
        {
            int Place = Hash1(post);
        repeatmark:
            if (!hashData[Place].Empty)  // если ячейка не пустая
            {
                while (!hashData[Place].Empty && hashData[Place].Post != post)  // пока не найдем пустую
                {
                    if (Place == GlobalVariables.hashMaxSize - 1)  // если это последний элемент
                    {
                        if (hashData[Place].Empty)      // если он пустой добавляем и выходим
                        {
                            hashData[Place].Key = Place;         // Place;           Hash1(post); 
                            hashData[Place].Post = post; 
                            hashData[Place].Phone = phone;
                            hashData[Place].Kat = kat;
                            hashData[Place].Empty = false;

                            goto thismark;
                        }

                        else if (!hashData[Place].Empty)  // если он не пустой
                        {
                            Place = 0;              // идем в начало     Collision++;
                            goto repeatmark;
                        }
                    }
                    Place++;  // иначе просто перейдем к следующей ячейке       Collision++;
                }
                if (hashData[Place].Post == post)
                {
                    MessageBox.Show("Такой поставщик уже есть");
                    goto thismark;
                }
            }
            hashData[Place].Key = Place;           // Place;         Hash1(post); 
            hashData[Place].Post = post;
            hashData[Place].Phone = phone;
            hashData[Place].Kat = kat;
            hashData[Place].Empty = false;
        thismark:;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TreeSizeFromTXT();
            HashSizeFromTXT();

            //----------------------------------------- HASH -------------------------------------------------------------
            for (int iter = 0; iter < GlobalVariables.hashMaxSize; iter++)
            {
                hashdata[iter] = new HashData
                {
                    Empty = true,
                    Deleted = false
                };
            }
            using (StreamReader reader = new StreamReader(GlobalVariables.hashfilepath, Encoding.UTF8))
            {
                for (int i = 0; i < GlobalVariables.hashsize; i++)
                {
                    string[] words = reader.ReadLine().Split('/');
                    string post = words[0];
                    string phone = words[1];
                    int kat = Convert.ToInt32(words[2]);

                    //int Collision = 0;
                    HashInsert(ref hashdata ,post, phone, kat);
                    int hash = Hash1(post);

                    if (hashdata[hash].Post == hashdata[hash + 1].Post)
                    {
                        hash++;
                        while (hashdata[hash - 1].Post == hashdata[hash].Post)
                        {
                            hash++;
                        }
                    }
                }
            }
            GlobalVariables.gridCounter = 0;
            GlobalVariables.hashsize = 0;
            GridClear(ref GridPost);
            HashObhod();
            GridPost.Rows.Add(GlobalVariables.hashsize);
            HashToForm(ref hashdata);
            //----------------------------------------- HASH -------------------------------------------------------------


            //----------------------------------------- TREE -------------------------------------------------------------
            TreeData.SkladData[] array = new TreeData.SkladData[GlobalVariables.treesize];
            using (StreamReader reader = new StreamReader(GlobalVariables.treefilepath, Encoding.UTF8))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    int Count = i + 1;
                    string[] words = reader.ReadLine().Split('/');

                    array[i] = new TreeData.SkladData
                    {
                        masTovar = Convert.ToString(words[0]),
                        masPost = Convert.ToString(words[1]),
                        masObiem = Convert.ToInt16(words[2])
                    };
                    try
                    {
                        tree.Insert(array[i].masTovar, array[i].masPost, array[i].masObiem);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                GlobalVariables.gridCounter = 0;
                GlobalVariables.treesize = 0;
                GridClear(ref GridTovar);
                tree.TreeObhod(ref tree);
                GridTovar.Rows.Add(GlobalVariables.treesize);
                TreeToForm(ref tree);

                array =  null;
            }
            //----------------------------------------- TREE -------------------------------------------------------------
        }

        private void SearchProv_Click(object sender, EventArgs e)
        {
            int gridCount = 0;
            int gridCount1 = 0;
            int gridCount2 = 0;
            int gridCount3 = 0;
            int gridCount4 = 0;

            int tovarCount = 0;
            int treeCount = 0;
            int Obiem = 0;
            string Phone = "";
            string Postavshik = "";

            while (gridCount1 < GlobalVariables.treesize)
            {
                GridTovar.Rows[gridCount1].Cells[0].Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
                GridTovar.Rows[gridCount1].Cells[1].Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
                GridTovar.Rows[gridCount1].Cells[2].Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
                GridTovar.Rows[gridCount1].Cells[3].Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);

                gridCount1++;
            }
            while (gridCount2 < GlobalVariables.hashsize)
            {
                GridPost.Rows[gridCount2].Cells[0].Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
                GridPost.Rows[gridCount2].Cells[1].Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
                GridPost.Rows[gridCount2].Cells[2].Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
                GridPost.Rows[gridCount2].Cells[3].Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
                GridPost.Rows[gridCount2].Cells[4].Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);

                gridCount2++;
            }
            SearchTovar searchTovar = new SearchTovar();
            searchTovar.Owner = this;
            searchTovar.ShowDialog();

            string FindPost = "";
            string FindPhone = "";
            void FindTovar(TreeData.TreeRoot mynode) 
            {
                if (tovarCount == 0)
                {
                    while (gridCount < GlobalVariables.treesize)
                    {
                        if ((string)GridTovar.Rows[gridCount].Cells[1].Value == searchTovar.SearchTovarBox.Text)
                        {
                            GridTovar.Rows[gridCount].Cells[0].Style.BackColor = System.Drawing.Color.FromArgb(105, 255, 115);
                            GridTovar.Rows[gridCount].Cells[1].Style.BackColor = System.Drawing.Color.FromArgb(105, 255, 115);
                            GridTovar.Rows[gridCount].Cells[2].Style.BackColor = System.Drawing.Color.FromArgb(105, 255, 115);
                            GridTovar.Rows[gridCount].Cells[3].Style.BackColor = System.Drawing.Color.FromArgb(105, 255, 115);
                            Postavshik = (string)GridTovar.Rows[gridCount].Cells[2].Value;
                            tovarCount++;
                        }
                        gridCount++;
                    }
                    while (gridCount3 < GlobalVariables.hashsize)
                    {
                        if ((string)GridPost.Rows[gridCount3].Cells[2].Value == Postavshik)
                        {
                            GridPost.Rows[gridCount3].Cells[0].Style.BackColor = System.Drawing.Color.FromArgb(105, 255, 115);
                            GridPost.Rows[gridCount3].Cells[1].Style.BackColor = System.Drawing.Color.FromArgb(105, 255, 115);
                            GridPost.Rows[gridCount3].Cells[2].Style.BackColor = System.Drawing.Color.FromArgb(105, 255, 115);
                            GridPost.Rows[gridCount3].Cells[3].Style.BackColor = System.Drawing.Color.FromArgb(105, 255, 115);
                            GridPost.Rows[gridCount3].Cells[4].Style.BackColor = System.Drawing.Color.FromArgb(105, 255, 115);
                            FindPhone = (string)GridPost.Rows[gridCount3].Cells[3].Value;
                        }
                        gridCount3++;
                    }
                }
                if (tovarCount > 0 && treeCount < tovarCount && mynode != null)
                {
                    
                    while (mynode != null && treeCount < tovarCount)
                    {
                        if (mynode.Tovar == searchTovar.SearchTovarBox.Text)
                        {
                            treeCount++;
                            if (treeCount == tovarCount)
                            {
                                Obiem = mynode.Obiem;
                                FindPost = mynode.Post;

                                while (gridCount4 < GlobalVariables.hashsize)
                                {
                                    if ((string)GridPost.Rows[gridCount4].Cells[2].Value == FindPost)
                                    {
                                        FindPhone = (string)GridPost.Rows[gridCount4].Cells[3].Value;
                                    }
                                    gridCount4++;
                                }
                            }
                            if (mynode.Tovar.CompareTo(searchTovar.SearchTovarBox.Text) == 1)
                            {
                                FindTovar(mynode.Left);
                            }

                            if (mynode.Tovar.CompareTo(searchTovar.SearchTovarBox.Text) == -1 || mynode.Tovar.CompareTo(searchTovar.SearchTovarBox.Text) == 0)
                            {
                                FindTovar(mynode.Right);
                            }
                        }
                        else
                        {
                            if (mynode.Tovar.CompareTo(searchTovar.SearchTovarBox.Text) == 1)
                            {
                                FindTovar(mynode.Left);
                            }

                            if (mynode.Tovar.CompareTo(searchTovar.SearchTovarBox.Text) == -1 || mynode.Tovar.CompareTo(searchTovar.SearchTovarBox.Text) == 0)
                            {
                                FindTovar(mynode.Right);
                            }
                        }
                    }
                }
                else
                {
                    if (tovarCount == 0)
                    {
                        MessageBox.Show("Такого товара нет на складе");
                        searchTovar.ShowDialog();
                    }
                }
            }
            if (searchTovar.DialogResult == DialogResult.OK)
            {
                if (searchTovar.SearchTovarBox.Text != "")
                {
                    FindTovar(tree);
                    if (tovarCount > 0)
                    {
                        if (HashFindPost(FindPost) == false)
                        {
                            MessageBox.Show("Найдено товаров" + " < " + searchTovar.SearchTovarBox.Text + " > " + "= " + Obiem + '\n' +
                                        "Поставщик не найден");
                        }
                        else
                        {
                            MessageBox.Show("Найдено товаров" + " < " + searchTovar.SearchTovarBox.Text + " > " + "= " + Obiem + '\n' +
                                        "Поставщик товара " + '<' + FindPost + '>' + '\n' +
                                        "Телефон поставщика " + " < " + FindPhone + " > ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Товар не найден");
                    }
                }
                else
                {
                    MessageBox.Show("Вы ничего не ввели!");
                    searchTovar.ShowDialog();
                }
            }
        }

        private void MinusTovar(object sender, EventArgs e)
        {
            MinusTovar deleteTovar = new MinusTovar();
            deleteTovar.Owner = this;
            deleteTovar.ShowDialog();

            if (deleteTovar.DialogResult == DialogResult.OK)
            {
                if (deleteTovar.DeleteTovarBox.Text != "" && deleteTovar.ObiemDeleteBox.Text != "")
                {
                    GlobalVariables.gridCounter = 0;
                    GlobalVariables.treesize = 0;

                    TreeMinus(ref tree, deleteTovar.DeleteTovarBox.Text, Convert.ToInt32(deleteTovar.ObiemDeleteBox.Text));

                    /*
                    if (TreeMinus(tree, deleteTovar.DeleteTovarBox.Text, Convert.ToInt32(deleteTovar.ObiemDeleteBox.Text)) != true)
                    {
                        MessageBox.Show("Такого товара нет на складе!");
                        deleteTovar.ShowDialog();
                    }
                    */

                    MessageBox.Show("Со склада удалено" + " < " + deleteTovar.DeleteTovarBox.Text + " > " + 
                                    "в количестве = " + deleteTovar.ObiemDeleteBox.Text + '.');
                }
                else
                {
                    MessageBox.Show("Вы ничего не ввели!");
                    deleteTovar.ShowDialog();
                }
                GridClear(ref GridTovar);
                tree.TreeObhod(ref tree);
                GridTovar.Rows.Add(GlobalVariables.treesize - 1);
                TreeToForm(ref tree);
                FirstTreeToTxt(ref tree);
            }
        }

        private void AddProv_Click(object sender, EventArgs e)
        {
            AddTovar addTovar = new AddTovar();
            addTovar.Owner = this;
            addTovar.ShowDialog();

            bool mistake = false;

            if (addTovar.DialogResult == DialogResult.OK)
            {
                try
                {
                    if (
                              addTovar.AddTovarBox.Text.Length > 25
                           || addTovar.AddTovarBox.Text.Contains("1")
                           || addTovar.AddTovarBox.Text.Contains("2")
                           || addTovar.AddTovarBox.Text.Contains("3")
                           || addTovar.AddTovarBox.Text.Contains("4")
                           || addTovar.AddTovarBox.Text.Contains("5")
                           || addTovar.AddTovarBox.Text.Contains("6")
                           || addTovar.AddTovarBox.Text.Contains("7")
                           || addTovar.AddTovarBox.Text.Contains("8")
                           || addTovar.AddTovarBox.Text.Contains("9")
                           || addTovar.AddTovarBox.Text.Contains("0")

                           || addTovar.AddPostBox.Text.Length > 25
                           || addTovar.AddPostBox.Text.Contains("1")
                           || addTovar.AddPostBox.Text.Contains("2")
                           || addTovar.AddPostBox.Text.Contains("3")
                           || addTovar.AddPostBox.Text.Contains("4")
                           || addTovar.AddPostBox.Text.Contains("5")
                           || addTovar.AddPostBox.Text.Contains("6")
                           || addTovar.AddPostBox.Text.Contains("7")
                           || addTovar.AddPostBox.Text.Contains("8")
                           || addTovar.AddPostBox.Text.Contains("9")
                           || addTovar.AddPostBox.Text.Contains("0")

                           || Convert.ToInt32(addTovar.AddObiemBox.Text) < 1
                           || Convert.ToInt32(addTovar.AddObiemBox.Text) > 10000  )
                    {
                        mistake = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    mistake = true;
                }
                if (mistake == false)
                {
                    if (addTovar.AddTovarBox.Text != "" && addTovar.AddObiemBox.Text != "" && addTovar.AddPostBox.Text != "" && Convert.ToInt32(addTovar.AddObiemBox.Text) > 0)
                    {
                        GlobalVariables.gridCounter = 0;
                        GlobalVariables.treesize = 0;

                        tree.TreeObhod(ref tree);

                        if (TreePlus(ref tree, addTovar.AddTovarBox.Text, addTovar.AddPostBox.Text, Convert.ToInt32(addTovar.AddObiemBox.Text)) == false)
                        {
                            tree.Insert(addTovar.AddTovarBox.Text, addTovar.AddPostBox.Text, Convert.ToInt32(addTovar.AddObiemBox.Text));
                            GlobalVariables.treesize++;
                        }
                        GridClear(ref GridTovar);
                        GridTovar.Rows.Add(GlobalVariables.treesize - 1);
                        TreeToForm(ref tree);
                        FirstTreeToTxt(ref tree);
                    }
                }
                else
                {
                    MessageBox.Show("Проверьте на корректность введенные данные");
                    addTovar.ShowDialog();
                }
            }
        }

        private void SearchPost_Click(object sender, EventArgs e)
        {
            //SearchPostClick();
            int gridCount = 0;
            int gridCount1 = 0;
            int gridCount2 = 0;
            int gridCount3 = 0;

            int postCount = 0;
            //int hashCount = 0;

            string Post = "";
            string Phone = "";
            string Tovar = "";
            int Obiem = 0;

            while (gridCount1 < GlobalVariables.treesize)
            {
                GridTovar.Rows[gridCount1].Cells[0].Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
                GridTovar.Rows[gridCount1].Cells[1].Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
                GridTovar.Rows[gridCount1].Cells[2].Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
                GridTovar.Rows[gridCount1].Cells[3].Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);

                gridCount1++;
            }
            while (gridCount2 < GlobalVariables.hashsize)
            {
                GridPost.Rows[gridCount2].Cells[0].Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
                GridPost.Rows[gridCount2].Cells[1].Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
                GridPost.Rows[gridCount2].Cells[2].Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
                GridPost.Rows[gridCount2].Cells[3].Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
                GridPost.Rows[gridCount2].Cells[4].Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);

                gridCount2++;
            }
            SearchPost searchPost = new SearchPost();
            searchPost.Owner = this;
            searchPost.ShowDialog();

            void FindPost()
            {
                if (postCount == 0)
                {
                    while (gridCount3 < GlobalVariables.hashsize)
                    {
                        if ((string)GridPost.Rows[gridCount3].Cells[2].Value == searchPost.SearchPostBox.Text)
                        {
                            GridPost.Rows[gridCount3].Cells[0].Style.BackColor = System.Drawing.Color.FromArgb(105, 255, 115);
                            GridPost.Rows[gridCount3].Cells[1].Style.BackColor = System.Drawing.Color.FromArgb(105, 255, 115);
                            GridPost.Rows[gridCount3].Cells[2].Style.BackColor = System.Drawing.Color.FromArgb(105, 255, 115);
                            GridPost.Rows[gridCount3].Cells[3].Style.BackColor = System.Drawing.Color.FromArgb(105, 255, 115);
                            GridPost.Rows[gridCount3].Cells[4].Style.BackColor = System.Drawing.Color.FromArgb(105, 255, 115);

                            postCount++;
                            Post = (string)GridPost.Rows[gridCount3].Cells[2].Value;
                            Phone = (string)GridPost.Rows[gridCount3].Cells[3].Value;
                        }
                        gridCount3++;
                    }
                    if (postCount < 1)
                    {
                        MessageBox.Show("Такого поставщика нет");
                        searchPost.ShowDialog();
                    }
                    while (gridCount < GlobalVariables.treesize)
                    {
                        if ((string)GridTovar.Rows[gridCount].Cells[2].Value == searchPost.SearchPostBox.Text)
                        {
                            GridTovar.Rows[gridCount].Cells[0].Style.BackColor = System.Drawing.Color.FromArgb(105, 255, 115);
                            GridTovar.Rows[gridCount].Cells[1].Style.BackColor = System.Drawing.Color.FromArgb(105, 255, 115);
                            GridTovar.Rows[gridCount].Cells[2].Style.BackColor = System.Drawing.Color.FromArgb(105, 255, 115);
                            GridTovar.Rows[gridCount].Cells[3].Style.BackColor = System.Drawing.Color.FromArgb(105, 255, 115);

                            Tovar = (string)GridTovar.Rows[gridCount].Cells[2].Value;
                            Obiem += (int)GridTovar.Rows[gridCount].Cells[3].Value;
                        }
                        gridCount++;
                    }
                }
            }
            if (searchPost.DialogResult == DialogResult.OK)
            {
                if (searchPost.SearchPostBox.Text != "")
                {
                    FindPost();
                    if (postCount > 0)
                    {
                        MessageBox.Show("Поставщик " + " < " + searchPost.SearchPostBox.Text + " > " + '\n' +
                                        "Телефон" + " < " + Phone + " > " + '\n' +
                                        "Объем всех поставок = " + Obiem);
                    }
                }
                else
                {
                    MessageBox.Show("Вы ничего не ввели!");
                    searchPost.ShowDialog();
                }
            }
        }

        private void AddPost_Click(object sender, EventArgs e)
        {
            AddPost addPost = new AddPost();
            addPost.Owner = this;
            addPost.ShowDialog();

            bool mistake = false;

            if (addPost.DialogResult == DialogResult.OK)
            {
                try
                {
                    if (
                              addPost.AddPostBox2.Text.Length > 25
                           || addPost.AddPostBox2.Text.Contains("1")
                           || addPost.AddPostBox2.Text.Contains("2")
                           || addPost.AddPostBox2.Text.Contains("3")
                           || addPost.AddPostBox2.Text.Contains("4")
                           || addPost.AddPostBox2.Text.Contains("5")
                           || addPost.AddPostBox2.Text.Contains("6")
                           || addPost.AddPostBox2.Text.Contains("7")
                           || addPost.AddPostBox2.Text.Contains("8")
                           || addPost.AddPostBox2.Text.Contains("9")
                           || addPost.AddPostBox2.Text.Contains("0")

                           || addPost.AddPhone.Text.Length > 9 
                           || Convert.ToInt32(addPost.AddPhone.Text) < 100000 
                           || Convert.ToInt32(addPost.AddPhone.Text) > 999999999

                           || !addPost.AddKat.Text.Contains("1")
                           || !addPost.AddKat.Text.Contains("2")
                           || !addPost.AddKat.Text.Contains("3")
                           || !addPost.AddKat.Text.Contains("4")  )
                    {
                        mistake = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    mistake = true;
                }
                if (mistake == false)
                {
                    if (addPost.AddPostBox2.Text != "" && addPost.AddPhone.Text != "" && addPost.AddKat.Text != "" && Convert.ToInt32(addPost.AddKat.Text) > 0)
                    {
                        GlobalVariables.gridCounter = 0;
                        GlobalVariables.hashsize = 0;

                        HashInsert(ref hashdata, addPost.AddPostBox2.Text, addPost.AddPhone.Text, Convert.ToInt32(addPost.AddKat.Text));
                        HashObhod();
                        GridClear(ref GridPost);
                        GridPost.Rows.Add(GlobalVariables.hashsize - 1);
                        HashToForm(ref hashdata);

                        FirstHashToTxt(ref hashdata);
                    }
                }
                else
                {
                    MessageBox.Show("Проверьте на корректность введенные данные");
                    addPost.ShowDialog();
                }
            }
        }

        private void DelProd_Click(object sender, EventArgs e)
        {
            MinusPost deletePost = new MinusPost();
            deletePost.Owner = this;
            deletePost.ShowDialog();

            int gridCount = 0;
            int Obiem = 0;
            int postCount = 0;

            if (deletePost.DialogResult == DialogResult.OK)
            {
                if (deletePost.DeletePostBox.Text != "")
                {
                    GlobalVariables.gridCounter = 0;
                    GlobalVariables.hashsize = 0;

                    HashDelete(ref hashdata, deletePost.DeletePostBox.Text);

                    while (gridCount < GlobalVariables.treesize)
                    {
                        if ((string)GridTovar.Rows[gridCount].Cells[2].Value == deletePost.DeletePostBox.Text)
                        {
                            Obiem += (int)GridTovar.Rows[gridCount].Cells[3].Value;
                            postCount++;
                        }
                        gridCount++;
                    }
                    if (postCount < 1)
                    {
                        MessageBox.Show("Такого поставщика нет");
                        deletePost.ShowDialog();
                    }
                    MessageBox.Show("Удален поставщик" + " < " + deletePost.DeletePostBox.Text + " > " +
                                    "Товаров поставщика на складе = " + Obiem + '.');
                }
                else
                {
                    MessageBox.Show("Вы ничего не ввели!");
                    deletePost.ShowDialog();
                }
                GridClear(ref GridPost);
                HashObhod();
                GridClear(ref GridPost);
                GridPost.Rows.Add(GlobalVariables.hashsize - 1);
                HashToForm(ref hashdata);

                    FirstHashToTxt(ref hashdata);
            }
        }
        string tTovar = "";
        int tObiem = 0;
        string PostHash = "";
        private void PostOtchet_Click(object sender, EventArgs e)
        {
            DoOtchetPost doOtchetPost = new DoOtchetPost();
            doOtchetPost.Owner = this;
            doOtchetPost.ShowDialog();

            TovarOtchet tovarOtchet = new TovarOtchet();
            tovarOtchet.Owner = this;
            tovarOtchet.PostTovara.Items.Clear();

            string tPost = doOtchetPost.SearchPostBox.Text;

            int tovarCount = 0;
            string arrayOtchet = "";

            TreeData.TreeNew treePost = new TreeData.TreeNew();
            TreeData.SkladData[] array = new TreeData.SkladData[GlobalVariables.treesize];

            using (StreamReader reader = new StreamReader(GlobalVariables.treefilepath, Encoding.UTF8))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    int Count = i + 1;
                    string[] words = reader.ReadLine().Split('/');

                    array[i] = new TreeData.SkladData
                    {
                        masTovar = Convert.ToString(words[0]),
                        masPost = Convert.ToString(words[1]),
                        masObiem = Convert.ToInt16(words[2])
                    };
                    try
                    {
                        treePost.InsertPostNew(array[i].masTovar, array[i].masPost, array[i].masObiem);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            bool HashFindPost(string post)
            {
                int Place = Hash1(post);
            repeatmark:
                int counter = 0;
                while (hashdata[Place].Post != post && counter < 10)  // пока не дойдем
                {
                    if (hashdata[Place].Post != post)  // если не совпало
                    {
                        Place++;  // иначе просто перейдем к следующей ячейке
                        counter++;
                        if (Place == GlobalVariables.hashMaxSize - 1)  // если это последний элемент
                        {
                            Place = 0;      // идем в начало
                            goto repeatmark;
                        }
                        if (hashdata[Place].Post != post)
                        {
                            return false;
                        }
                    }
                }
                if (hashdata[Place].Post == post)
                {
                    PostHash = hashdata[Place].Post;
                    return true;
                }
                return false;
            }

            void FindPostOtchet(TreeData.TreeNew newtree)
            {
                if (newtree != null)
                {
                    if (newtree.Post == PostHash)
                    {
                        tTovar = newtree.Tovar;
                        tObiem = newtree.Obiem;
                        arrayOtchet = tTovar + "    " + tObiem;
                        tovarOtchet.PostTovara.Items.Add(arrayOtchet);

                        if (newtree.Tovar.CompareTo(PostHash) == 1)
                        {
                            FindPostOtchet(newtree.Left);
                        }
                        if (newtree.Tovar.CompareTo(PostHash) == -1 || newtree.Tovar.CompareTo(PostHash) == 0)
                        {
                            FindPostOtchet(newtree.Right);
                        }
                    }
                    else
                    {
                        if (newtree.Tovar.CompareTo(PostHash) == 1)
                        {
                            FindPostOtchet(newtree.Left);
                        }
                        if (newtree.Tovar.CompareTo(PostHash) == -1 || newtree.Tovar.CompareTo(PostHash) == 0)
                        {
                            FindPostOtchet(newtree.Right);
                        }
                    }
                }
            }
            if (doOtchetPost.DialogResult == DialogResult.OK)
            {
                if (doOtchetPost.SearchPostBox.Text != "")
                {
                    if (HashFindPost(tPost) == true)
                    {
                        FindPostOtchet(treePost);
                        tovarOtchet.Show();
                    }
                    else
                    {
                        MessageBox.Show("Такого поставщика нет");
                        doOtchetPost.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Вы ничего не ввели!");
                    doOtchetPost.ShowDialog();
                }
            }
        }
        string HashPost = "";
        string pPhone = "";
        string Post = "";
        int pKat = 0;

        private void TovarOtchet_Click(object sender, EventArgs e)
        {
            DoOtchetTovar doOtchetTovar = new DoOtchetTovar();
            doOtchetTovar.Owner = this;
            doOtchetTovar.ShowDialog();

            TovarOtchet tovarOtchet = new TovarOtchet();
            tovarOtchet.Owner = this;
            tovarOtchet.PostTovara.Items.Clear();

            string Tovar = doOtchetTovar.SearchTovarBox.Text;
            int tovarCount = 0;

            void FindTovarOtchet(ref TreeData.TreeRoot mynode)
            {
                if (mynode != null && tovarCount < 1)
                {
                    if (mynode.Tovar == Tovar)
                    {
                        Post = mynode.Post;
                        tovarCount++;
                    }
                    else
                    {
                        if (mynode.Tovar.CompareTo(Tovar) == 1)
                        {
                            FindTovarOtchet(ref mynode.Left);
                        }
                        if (mynode.Tovar.CompareTo(Tovar) == -1 || mynode.Tovar.CompareTo(Tovar) == 0)
                        {
                            FindTovarOtchet(ref mynode.Right);
                        }
                    }
                }
                if (tovarCount < 1)
                {
                    MessageBox.Show("Такого товара нет на складе");
                    doOtchetTovar.ShowDialog();
                }
            }

            bool HashFindPost(string post)
            {
                int Place = Hash1(post);
            repeatmark:
                int counter = 0;
                while (hashdata[Place].Post != post && counter < 25)  // пока не дойдем
                {
                    if (hashdata[Place].Post != post)  // если не совпало
                    {
                        Place++;  // иначе просто перейдем к следующей ячейке
                        counter++;
                        if (Place == GlobalVariables.hashMaxSize - 1)  // если это последний элемент
                        {
                            Place = 0;      // идем в начало
                            goto repeatmark;
                        }
                    }
                }
                if (hashdata[Place].Post == post)
                {
                    HashPost = hashdata[Place].Post;
                    pPhone = hashdata[Place].Phone;
                    pKat = hashdata[Place].Kat;

                    string arrayOtchet = HashPost + "    " + pPhone + "    " + pKat + '\n';
                    tovarOtchet.PostTovara.Items.Add(arrayOtchet);

                    return true;
                }
                return false;
            }
            if (doOtchetTovar.DialogResult == DialogResult.OK)
            {
                if (doOtchetTovar.SearchTovarBox.Text != "")
                {
                    FindTovarOtchet(ref tree);
                    if (HashFindPost(Post) == true)
                    {
                        tovarOtchet.Show();
                    }
                    else
                    {
                        MessageBox.Show("Такого поставщика нет");
                        doOtchetTovar.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Вы ничего не ввели!");
                    doOtchetTovar.ShowDialog();
                }
            }
        }
    }
}
