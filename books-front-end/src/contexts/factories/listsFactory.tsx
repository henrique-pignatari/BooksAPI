import { ReactNode, createContext, useState } from "react";
import axios from 'axios';

type ListContextData<T> = {
  loading: boolean;
  list: Array<T>
  fetchList: () => Promise<void>
}

type ListProviderFactoryProps = {
  baseUrl: string;
}

function listProviderFactory<T>({baseUrl}: ListProviderFactoryProps){
  const context = createContext<ListContextData<T>>({} as ListContextData<T>);
  
  const ProviderElement = (children: ReactNode) => {
    const [loading, setLoading] = useState(false);
    const [list, setList] = useState<Array<T>>([]);

    const fetchList = async () => {
      axios.get(baseUrl)
      .then((response)=>{
        setLoading(false);
        console.log({data: response.data});
      })
      .catch((err)=>{
        console.log(err);
      })

      setLoading(true);
    }

    return(
      <context.Provider value={{
        list,
        fetchList,
        loading,
      }}>
        {children}
      </context.Provider>
    )
  }

  return{
    ProviderElement,
    context
  }
}

export {
  listProviderFactory
}

