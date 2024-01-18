import Author from "./author";
import Category from "./category";
import Genre from "./genre";
import Publisher from "./publisher";

type Book = {
  id: string;
  name: string;
  description: string;
  totalPages: number;
  image: string;
  readStatus: number;
  readStartDate: Date;
  readStopDate: Date;
  readConclusionDate: Date;
  publisher: Publisher;
  category: Category;
  genres: Array<Genre>;
  auhtors: Array<Author>;
};

export default Book