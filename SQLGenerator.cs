using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            using (StreamWriter f = new StreamWriter("test.txt", true))
            {
                // Do nothing
            }
        }
        catch (FileNotFoundException)
        {
            using (StreamWriter f = new StreamWriter("test.txt"))
            {
                // Do nothing
            }
        }
        finally
        {
            using (StreamWriter f = new StreamWriter("test.txt", true))
            {
                string[] files = Directory.GetFiles(@"C:\absolute\path\to\your\.nitros"); //Absolute path to your files
                int n = 1;  // your starting last number for adding on  items_base and catalog_items
                int page_id = 1;  // your page_id where the furnis will be added on catalog.
                foreach (string furni_name in files)
                {
                    string name_for_insert = Path.GetFileNameWithoutExtension(furni_name);
                    f.WriteLine($"INSERT INTO `items_base` (`id`, `sprite_id`, `item_name`, `public_name`, `width`, `length`, `stack_height`, `allow_stack`, `allow_sit`, `allow_lay`, `allow_walk`, `allow_gift`, `allow_trade`, `allow_recycle`, `allow_marketplace_sell`, `allow_inventory_stack`, `type`, `interaction_type`, `interaction_modes_count`, `vending_ids`, `multiheight`, `customparams`, `effect_id_male`, `effect_id_female`, `clothing_on_walk`) VALUES ('{n}', '{n}', '{name_for_insert}', '{name_for_insert}', 1, 1, 1.00, '0', '0', '0', '0', '1', '1', '0', '0', '1', 's', 'default', 2, '', '', '', 0, 0, '');");
                    f.WriteLine($"INSERT INTO `catalog_items` (`id`, `item_ids`, `page_id`, `offer_id`, `song_id`, `order_number`, `catalog_name`, `cost_credits`, `cost_points`, `points_type`, `amount`, `limited_sells`, `limited_stack`, `extradata`, `have_offer`, `club_only`, `rate`) VALUES ('{n}', '{n}', '{page_id}', '{n}', 0, 99, '{name_for_insert}', '0', 0, 0, 1, 0, 0, '', '1', '0', 'none');");
                    n++;
                }
            }
        }
    }
}
